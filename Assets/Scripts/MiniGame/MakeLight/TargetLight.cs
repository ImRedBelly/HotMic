using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetLight : MonoBehaviour
{
    public SpriteRenderer sprite;

    Color col;
    float a = 0.1f;

    void Start()
    {
        col = sprite.color;
        col.a = a;
        sprite.color = col;
    }
    private void Update()
    {
        if(col.a == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void ColorAlpha()
    {
        a += 0.3f;
        col.a = a;
        sprite.color = col;
    }
}
