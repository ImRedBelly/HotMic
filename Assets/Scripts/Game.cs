using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text mainJoke;
    public Text[] answers;

    public MoodBar moodBar;

    public List<Jokes> jokes;

    public GameObject[] canvasElement;
    public GameObject goodSmile;
    public GameObject badSmile;
    public GameObject pinata;

    int countJokes;
    int countAnswer;

    int trueAnswer = 0;

    void Start()
    {
        UpdateJokes();
    }
    void Update()
    {
        if(moodBar.slider.value == moodBar.slider.maxValue)
        {
            print("YOU WIN");
        }    
    }

    public void Button(int nummer)
    {
        if (answers[nummer].text.ToString() != jokes[countJokes].endJoke[0])
        {
            trueAnswer = 0;
            StartCoroutine(SpawnSmile());
            badSmile.SetActive(true);
        }
        else
        {
            trueAnswer++;
            StartCoroutine(SpawnSmile());
            goodSmile.SetActive(true);
        }

        jokes.RemoveAt(countJokes);
    }

    void UpdateJokes()
    {
        countJokes = Random.Range(0, jokes.Count);
        mainJoke.text = jokes[countJokes].jokeStart;

        List<string> answer = new List<string>(jokes[countJokes].endJoke);

        for (int i = 0; i < jokes[countJokes].endJoke.Length; i++)
        {
            countAnswer = Random.Range(0, answer.Count);
            answers[i].text = answer[countAnswer];
            answer.RemoveAt(countAnswer);
        }
    }

    IEnumerator SpawnSmile()
    {
        if (jokes.Count > 0)
        {
            for (int i = 0; i < canvasElement.Length; i++)
            {
                canvasElement[i].SetActive(false);
            }

            yield return new WaitForSeconds(10);
            UpdateJokes();

            for (int i = 0; i < canvasElement.Length; i++)
            {
                canvasElement[i].SetActive(true);
            }

            goodSmile.SetActive(false);
            badSmile.SetActive(false);

            if (trueAnswer == 2)
            {
                Instantiate(pinata);
                trueAnswer = 0;
            }
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
