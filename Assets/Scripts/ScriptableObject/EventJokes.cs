using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventJokes", fileName = "EventJokes_")]
public class EventJokes : ScriptableObject
{
    [TextArea(10, 20)]
    public string jokeStart;
    public Sprite[] answerJokes;

    public int trueAnswer;
}
