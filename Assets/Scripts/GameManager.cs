using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nameScene;

    public Text mainJoke;  // основа шутки
    public GameObject mainJokeObject;
    public Image[] imagesAnswer;  // два ответа шутки 

    public AudioManager audioManager;
    public MoodBar moodBar;  // шкала настроения
    public Animator animator;
    public Animator animatorEventJoke;

    public Text result; // текст о окончании уровня на резалтскрин

    public List<Jokes> jokes;  // лист шуток 
    public List<EventJokes> eventJokes;  // лист добивочек (ОДНА НА СЦЕНУ!!!)

    public GameObject[] canvasElement;  // это кнопки ответа и шутка
    public GameObject goodSmile;  // спавнер хороших смайлов
    public GameObject badSmile;  // спавнер плохих смайлов

    [Header("Score Setting")]
    public GameObject resultScreen;
    public Text yourScore;



    public static string moneyKey = "Money";  // сохранение денег
    public int moneyInt = 0;
    public int moneyForPerformance = 0;


    public int countJokes;
    public int trueAnswer = 0;


    public AudioClip woo;
    public AudioClip poo;
    public AudioClip bravo;
    public AudioClip priest;
    public AudioClip[] goodAnswer;
    public AudioClip[] badAnswer;



    [Header("Setting Tutor")]
    public GameObject tutor;
    public GameObject mainText;
    public Text swipe;
    public Text tap;

    [Header("Setting Pinata")]
    public GameObject pinata;
    public GameObject tutorPinata;



    void Start()
    {
        TinySauce.OnGameStarted(nameScene);
        Vibration.Init();

        audioManager.audioSource.Play();
        moneyInt = PlayerPrefs.GetInt(moneyKey);
        moneyForPerformance = 0;


        UpdateJokes();

        Tutor();
    }

    void UpdateJokes()
    {
        if (tutor != null)
            tutor.SetActive(false);


        countJokes = Random.Range(0, jokes.Count);

        mainJoke.text = jokes[countJokes].jokeStart;

        imagesAnswer[0].sprite = jokes[countJokes].answerJokes[0];
        imagesAnswer[1].sprite = jokes[countJokes].answerJokes[1];
    }

    void UpdateEventJokes()
    {
        mainJoke.text = eventJokes[0].jokeStart;
        imagesAnswer[0].sprite = eventJokes[0].answerJokes[0];
        imagesAnswer[1].sprite = eventJokes[0].answerJokes[1];
    }


    public void Button(int numerAnswer)
    {
        Vibration.Vibrate();

        if (jokes.Count > 0)
        {
            if (numerAnswer == jokes[countJokes].trueAnswer)
            {
                mainJoke.text = jokes[countJokes].jokeStart + " " + jokes[countJokes].jokeFinish[numerAnswer];
                TrueAnswer();
                SpeakGoodJoke();
            }
            else
            {
                mainJoke.text = jokes[countJokes].jokeStart + " " + jokes[countJokes].jokeFinish[numerAnswer];
                FalseAnswer();
                SpeakBadJoke();
            }

            jokes.RemoveAt(countJokes);

            if (tutor != null)
            {
                swipe.gameObject.SetActive(false);
                tap.gameObject.SetActive(true);
            }
        }
        else
        {
            if (numerAnswer == eventJokes[0].trueAnswer)
            {
                SpeakGoodJoke();
                SoundPriest();
                mainJoke.text = eventJokes[0].jokeStart + " " + eventJokes[0].jokeFinal;
                AnimationEventJoke();
                FinalyBonus();
            }
            else
            {
                SpeakGoodJoke();
                SoundPriest();
                mainJoke.text = eventJokes[0].jokeStart + " " + eventJokes[0].jokeFinal;
                AnimationEventJoke();
                FinalyBonus();
            }
            eventJokes.RemoveAt(0);
        }
    }




    public void FinalyBonus()
    {
        StartCoroutine(BonusEfect());
    }
    public IEnumerator BonusEfect()
    {
        WorkCanvacElement(false);
        yield return new WaitForSeconds(7);
        UpdateAfterAnswer();
    }


    void UpdateAfterAnswer()
    {
        DestroySmile();
        SpawnerSmile(false);
        WorkCanvacElement(true);




        if (jokes.Count > 0)
        {
            UpdateJokes();

            if (trueAnswer == 2)    // это число правильных ответов, после которых пояляется пиньята
            {
                Instantiate(pinata);
                tutorPinata.SetActive(true);
                mainJokeObject.SetActive(false);
                trueAnswer = 0;
            }
        }
        else if (eventJokes.Count > 0)
        {
            UpdateEventJokes();
        }
        else if (eventJokes.Count == 0)
        {
            mainJokeObject.SetActive(false);       // обрати на это внимание
            resultScreen.SetActive(true);
            audioManager.PlaySound(bravo);
            SaveMoney();

            if (tutor != null)
            {
                print(" im save");
                TutorManager.instance.SaveExperience(1);

                tutor.SetActive(false);
            }

            yourScore.text = "" + moneyForPerformance;
            Vibration.VibrateNope();

            if (moodBar.slider.value > 7.5f)
            {
                result.text = "Perfect";
                result.color = moodBar.fill.color;
            }
            else if (moodBar.slider.value < 7.5f && moodBar.slider.value > 5f)
            {
                result.text = "Cool";
                result.color = moodBar.fill.color;
            }
            else if (moodBar.slider.value < 5f && moodBar.slider.value > 2.5f)
            {
                result.text = "Good";
                result.color = moodBar.fill.color;
            }
            else if (moodBar.slider.value < 2.5f)
            {
                result.text = "Not Bad";
                result.color = moodBar.fill.color;
            }

            TinySauce.OnGameFinished(nameScene, moneyForPerformance);

        }
    }


    public void EndGame()
    {
        var index = Random.Range(0, CounerScenes.instance.IndexScene.Count);
        SceneManager.LoadScene(CounerScenes.instance.IndexScene[index]);
        CounerScenes.instance.IndexScene.RemoveAt(index);
        if (CounerScenes.instance.IndexScene.Count <= 0)
        {
            CounerScenes.instance.ResetIndexScene();
        }
    }

    public void TrueAnswer()
    {
        audioManager.PlaySound(woo);
        trueAnswer++;

        moneyForPerformance += 2;

        StartCoroutine(BonusEfect());
        goodSmile.SetActive(true);
    }
    public void FalseAnswer()
    {
        audioManager.PlaySound(poo);
        trueAnswer--;

        moneyForPerformance += 1;

        StartCoroutine(BonusEfect());
        badSmile.SetActive(true);
    }



    public void WorkCanvacElement(bool trigger)
    {
        for (int i = 0; i < canvasElement.Length; i++)
        {
            canvasElement[i].SetActive(trigger);
        }
    }

    public void SpawnerSmile(bool trigger)
    {
        goodSmile.SetActive(trigger);
        badSmile.SetActive(trigger);
    }

    public void DestroySmile()
    {
        SmileScript[] allSmile = FindObjectsOfType<SmileScript>();
        for (int i = 0; i < allSmile.Length; i++)
        {
            Destroy(allSmile[i].gameObject);
        }
    }


    public void SpeakGoodJoke()
    {
        audioManager.PlaySound(goodAnswer[Random.Range(0, goodAnswer.Length)]);
        animator.SetTrigger("Speak");
    }
    public void SpeakBadJoke()
    {
        audioManager.PlaySound(badAnswer[Random.Range(0, badAnswer.Length)]);
        animator.SetTrigger("SadAnswer");
    }
    public void SaveMoney()
    {
        PlayerPrefs.SetInt(moneyKey, moneyInt + moneyForPerformance);
    }

    public void AnimationEventJoke()
    {
        animatorEventJoke.SetTrigger("SpecialJoke");
    }



    public void Tutor()
    {
        if (tutor != null && SceneManager.GetActiveScene().buildIndex == 1)
        {
            tutor.SetActive(true);
            swipe.gameObject.SetActive(true);
        }
    }


    public void SoundPriest()
    {
        StartCoroutine(Priest());
    }
    IEnumerator Priest()
    {

        yield return new WaitForSeconds(1.3f);
        audioManager.PlaySound(priest);
    }
}

