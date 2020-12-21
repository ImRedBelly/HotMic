using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Jokes", fileName = "Jokes_")]
public class Jokes : ScriptableObject
{
    [TextArea(10, 20)]
    public string jokeStart;

    [TextArea(10, 20)]
    public string[] endJoke;

    public int trueAnswer = 1;
    public int falseAnswer = -1;
}
