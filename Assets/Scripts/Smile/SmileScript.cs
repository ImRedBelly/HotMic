using UnityEngine;

public class SmileScript : MonoBehaviour
{
    public int point;
    public int speed = 3;

    bool upDown = true;

    MoodBar moodBar;

    void Start()
    {
        moodBar = FindObjectOfType<MoodBar>();
    }
    void Update()
    {
        Move();
    }
    void OnMouseDown()
    {
        moodBar.SetPoint(point);
        Destroy(gameObject);
    }
    void Move()
    {
        if (upDown)
        {
            if (transform.position.y < 0)
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
