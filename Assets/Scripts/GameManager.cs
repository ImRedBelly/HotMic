using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    
    public Text mainJoke;  // основа шутки
    public GameObject mainJokeObject;
    public SpriteRenderer[] swipeImagesAnswer;  // два ответа шутки 

    public AudioManager audioManager;
    public Animator animator;
    public Animator animatorEventJoke;
    public MoodBar moodBar;  // шкала настроения

    public List<Jokes> jokes;  // лист шуток 
    public List<EventJokes> eventJokes;  // лист добивочек (ОДНА НА СЦЕНУ!!!)

    public GameObject[] square;  // анимации при добивках (ПОКА ЧТО ЭТО ПРОСТО КВАРДРАТЫ)


    public GameObject[] canvasElement;  // это кнопки ответа и шутка
    public GameObject goodSmile;  // спавнер хороших смайлов
    public GameObject badSmile;  // спавнер плохих смайлов

    public GameObject pinata;

    [Header("Score Setting")]
    public GameObject resultScreen;
    public Text yourScore;
    


    public static string moneyKey = "Money";  // сохранение денег
    public int moneyInt = 0;


    public int countJokes;
    public int trueAnswer = 0;


    public AudioClip woo;
    public AudioClip poo;
    void Start()
    {
        audioManager.audioSource.Play();

        moneyInt = PlayerPrefs.GetInt(moneyKey);
        UpdateJokes();
    }
    void Update()
    {
        
    }
    void UpdateJokes()
    {
        countJokes = Random.Range(0, jokes.Count);

        mainJoke.text = jokes[countJokes].jokeStart;
        swipeImagesAnswer[0].sprite = jokes[countJokes].answerJokes[0];
        swipeImagesAnswer[1].sprite = jokes[countJokes].answerJokes[1];
    }

    void UpdateEventJokes()
    {
        mainJoke.text = eventJokes[0].jokeStart;
        swipeImagesAnswer[0].sprite = eventJokes[0].answerJokes[0];
        swipeImagesAnswer[1].sprite = eventJokes[0].answerJokes[1];
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
                trueAnswer = 0;
            }
        }
        else if (eventJokes.Count > 0)
        {
            UpdateEventJokes();
        }
        else if(eventJokes.Count == 0)
        {
            OffBonusEfect();
            mainJokeObject.SetActive(false);       // обрати на это внимание
            resultScreen.SetActive(true);
            yourScore.text = "" + moneyInt;
        }
    }
    public void TrueAnswer()
    {
        audioManager.PlaySound(woo);
        trueAnswer++;

        moneyInt += 2;
        SaveMoney();
        StartCoroutine(BonusEfect());
        goodSmile.SetActive(true);
    }
    public void FalseAnswer()
    {
        audioManager.PlaySound(poo);
        trueAnswer--;

        moneyInt += 1;
        SaveMoney();
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


    public void OffBonusEfect()
    {
        for (int i = 0; i < square.Length; i++)
        {
            square[i].SetActive(false);
        }
    }

    public void SpeakJoke()
    {
        animator.SetTrigger("Speak");
    }
    public void SaveMoney()
    {
        PlayerPrefs.SetInt(moneyKey, moneyInt);
    }

    public void AnimationEventJoke()
    {
        animatorEventJoke.SetTrigger("SpecialJoke");
    }
}

