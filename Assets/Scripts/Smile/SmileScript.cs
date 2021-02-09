using System.Collections;
using UnityEngine;

public class SmileScript : MonoBehaviour
{
    public ParticleSystem spawnSmile;
    public int point;
    public int speed = 3;

    bool upDown = true;

    MoodBar moodBar;
    void Start()
    {
        Vibration.Init();
        moodBar = FindObjectOfType<MoodBar>();
    }
    void Update()
    {
        Move();
    }
    void OnMouseDown()
    {
        DestoySmile();
    }

    void DestoySmile()
    {
        Vibration.VibratePop();
        moodBar.SetPoint(point);
        var smile = Instantiate(spawnSmile, transform.position, Quaternion.identity);
        smile.Play();

        Destroy(gameObject);
    }
    void Move()
    {
        if (upDown)
        {
            if (transform.position.y < 0.85f)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
            else
            {
                upDown = false;
            }
        }
        else
        {
            if (transform.position.y > -4.2f)
            {
                transform.Translate(-Vector2.up * Time.deltaTime * speed);
            }
            else
            {
                upDown = true;
            }
        }
    }
}
