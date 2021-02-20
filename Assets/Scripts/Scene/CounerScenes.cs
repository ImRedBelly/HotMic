using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounerScenes : MonoBehaviour
{
    public static CounerScenes instance;
    public List<int> IndexScene;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance == this)
            Destroy(gameObject);
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ResetIndexScene()
    {
        IndexScene = new List<int> { 2, 3, 4, 6, 8, 10, 11, 12, 14, 16, 18, 19, 20 };
    }
}
