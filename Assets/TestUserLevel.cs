using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUserLevel : MonoBehaviour
{
    public string nameScene;
    void Start()
    {
        TinySauce.OnGameStarted(nameScene);
    }
}
