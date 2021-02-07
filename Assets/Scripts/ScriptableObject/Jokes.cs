using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Jokes", fileName = "Jokes_")]
public class Jokes : ScriptableObject
{
    [TextArea(10, 20)]

    public string jokeStart;
    public string[] jokeFinish;

    public Sprite[] answerJokes;
    public int trueAnswer;


}
