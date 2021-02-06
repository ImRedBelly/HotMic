using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Answer : MonoBehaviour
{
    public GameManager gameManager;
    Vector2 startPosisiton;
    public int answerNumber;

    private void Start()
    {
        startPosisiton = transform.position;
    }
    public void Left()
    {
        StartCoroutine(Slide(-Vector2.right));
       
        print(answerNumber);
    }
    public void Right()
    {
        StartCoroutine(Slide(Vector2.right));

        print(answerNumber);
    }


    IEnumerator Slide(Vector2 right)
    {
        float time = 0;
        while (time < 0.5f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
            transform.Translate(right * 20 * Time.deltaTime);
        }
        yield return new WaitForSeconds(1);
        UpdateAnswer();

        

    }

    void UpdateAnswer()
    {

        if (gameManager.jokes.Count > 0)
        {

            if (answerNumber == gameManager.jokes[gameManager.countJokes].trueAnswer)
            {
                gameManager.mainJoke.text = gameManager.jokes[gameManager.countJokes].jokeFinish[answerNumber];
                gameManager.TrueAnswer();
            }
            else
            {
                gameManager.mainJoke.text = gameManager.jokes[gameManager.countJokes].jokeFinish[answerNumber];
                gameManager.FalseAnswer();
            }

            gameManager.jokes.RemoveAt(gameManager.countJokes);
            transform.position = startPosisiton;
        }
        else
        {
            if (answerNumber == gameManager.eventJokes[0].trueAnswer)
            {
                gameManager.square[0].SetActive(true);
                gameManager.FinalyBonus();
            }
            else
            {
                gameManager.square[1].SetActive(true);
                gameManager.FinalyBonus();
            }
            gameManager.eventJokes.RemoveAt(0);
            transform.position = startPosisiton;
        }
    }
}






