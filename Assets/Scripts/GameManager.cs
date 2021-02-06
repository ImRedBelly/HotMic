using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text mainJoke;  // основа шутки
    public SpriteRenderer[] swipeImagesAnswer;  // два ответа шутки 

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
    public int score;


    public static string moneyKey = "Money";  // сохранение денег
    int moneyInt = 0;


    public int countJokes;
    int trueAnswer = 0;

    void Start()
    {
        moneyInt = PlayerPrefs.GetInt(moneyKey);
        UpdateJokes();
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


    public void Button(int nummer)
    {
        //if (jokes.Count > 0)
        //{

        //    if (nummer == jokes[countJokes].trueAnswer)
        //    {
        //        mainJoke.text = jokes[countJokes].jokeFinish[nummer];
        //        TrueAnswer();
        //    }
        //    else
        //    {
        //        mainJoke.text = jokes[countJokes].jokeFinish[nummer];
        //        FalseAnswer();
        //    }

        //    jokes.RemoveAt(countJokes);
        //}

        //else
        //{
        //    if (nummer == eventJokes[0].trueAnswer)
        //    {
        //        square[0].SetActive(true);
        //        StartCoroutine(BonusEfect());
        //    }
        //    else
        //    {
        //        square[1].SetActive(true);
        //        StartCoroutine(BonusEfect());
        //    }

        //    eventJokes.RemoveAt(0);
        //}
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
            print("я все");
            OffBonusEfect();
            resultScreen.SetActive(true);
            yourScore.text = "Score: " + score;
        }
    }
    public void TrueAnswer()
    {
        trueAnswer++;

        score++;

        moneyInt += 2;
        SaveMoney();
        StartCoroutine(BonusEfect());
        goodSmile.SetActive(true);
    }
    public void FalseAnswer()
    {
        trueAnswer--;

        score--;

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

    public void DestroySmile()       //все смайлы для уничтожения!
    {
        SmileScript[] allSmile = FindObjectsOfType<SmileScript>();
        for (int i = 0; i < allSmile.Length; i++)
        {
            Destroy(allSmile[i].gameObject);
        }
    }


    public void OffBonusEfect()
    {
        print("я все dct");
        for (int i = 0; i < square.Length; i++)
        {
            square[i].SetActive(false);
        }
    }


    public void SaveMoney()
    {
        PlayerPrefs.SetInt(moneyKey, moneyInt);
    }

}

