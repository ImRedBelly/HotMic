using UnityEngine;
using System.Collections;

public class Pinata : MonoBehaviour
{
    GameObject[] canvas;
    GameObject[] spawner;
    void Start()
    {
        canvas = GameObject.FindGameObjectsWithTag("Canvas");
        spawner = GameObject.FindGameObjectsWithTag("Spawner");

        StartCoroutine(DownPinata());
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 1.8f), Time.deltaTime);

        if(transform.position.y == 3.5f)
        {
             transform.position = new Vector2(transform.position.x, 3.5f);
        }
    }
    IEnumerator DownPinata()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        } 

        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i].SetActive(false);
        }

        yield return new WaitForSeconds(5);

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(true);
        }

        Destroy(gameObject);
    }
    void OnMouseDown()
    {
        print("BONUS");
    }
}
