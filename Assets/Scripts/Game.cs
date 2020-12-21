using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public Text mainJoke;
    public Text[] answers;

    public MoodBar moodBar;

    public List<Jokes> jokes;
    int countJokes;
    int countAnswer;

    private void Start()
    {
        UpdateJokes();
        //moodBar.SetPoint(5);
    }
    public void Button(int nummer)
    {

        if (answers[nummer].text.ToString() != jokes[countJokes].endJoke[0])
        {
            moodBar.SetPoint(jokes[countJokes].falseAnswer);
        }
        else
        {
            moodBar.SetPoint(jokes[countJokes].trueAnswer);
        }
        jokes.RemoveAt(countJokes);
        UpdateJokes();



    }

    void UpdateJokes()
    {

        if (jokes.Count > 0)
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


        else
        {
            print("The End");
        }

    }
}
