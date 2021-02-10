using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Answer : MonoBehaviour
{
    public GameManager gameManager;

    public int answerNumber;

    Vector2 startPosisiton;

    private void Start()
    {
        Vibration.Init();
        startPosisiton = transform.position;
    }
    public void Left()
    {
        Vibration.Vibrate();
        StartCoroutine(Slide(-Vector2.right));
    }
    public void Right()
    {
        Vibration.Vibrate();
        StartCoroutine(Slide(Vector2.right));
    }


    IEnumerator Slide(Vector2 right)
    {
        gameManager.SpeakJoke();

        float time = 0;
        while (time < 0.3f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
            transform.Translate(right * 20 * Time.deltaTime);
        }

        UpdateAnswer();
    }

    void UpdateAnswer()
    {
        if (gameManager.jokes.Count > 0)
        {

            if (answerNumber == gameManager.jokes[gameManager.countJokes].trueAnswer)
            {
                gameManager.mainJoke.text = gameManager.jokes[gameManager.countJokes].jokeStart + " " + gameManager.jokes[gameManager.countJokes].jokeFinish[answerNumber];
                gameManager.TrueAnswer();
            }
            else
            {
                gameManager.mainJoke.text = gameManager.jokes[gameManager.countJokes].jokeStart + " " + gameManager.jokes[gameManager.countJokes].jokeFinish[answerNumber];
                gameManager.FalseAnswer();
            }

            gameManager.jokes.RemoveAt(gameManager.countJokes);

            if (gameManager.tutor != null)
            {
                gameManager.swipe.gameObject.SetActive(false);
                gameManager.tap.gameObject.SetActive(true);
            }

            transform.position = startPosisiton;
        }
        else
        {
            if (answerNumber == gameManager.eventJokes[0].trueAnswer)
            {
                gameManager.AnimationEventJoke();
                gameManager.FinalyBonus();
            }
            else
            {
                gameManager.AnimationEventJoke();
                gameManager.FinalyBonus();
            }
            gameManager.eventJokes.RemoveAt(0);
            transform.position = startPosisiton;
        }
    }
}






