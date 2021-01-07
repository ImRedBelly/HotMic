using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    public GameManager game;

    void Start()
    {
        if (gameObject.activeSelf == true)
        {
            game.WorkCanvacElement(false);
            game.SpawnerSmile(false);
            game.DestroySmile();
        }
    }
}
