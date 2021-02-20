using UnityEngine;
using System.Collections;

public class Pinata : MonoBehaviour
{
    public Animator animator;
    GameManager gameManager;
    void Start()
    {
        Vibration.Init();
        gameManager = FindObjectOfType<GameManager>();


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
        gameManager.WorkCanvacElement(false);

        yield return new WaitForSeconds(5);

        gameManager.WorkCanvacElement(true);
        gameManager.tutorPinata.SetActive(false);
        gameManager.mainJokeObject.SetActive(true);
        Destroy(gameObject);
    }
    void OnMouseDown()
    {
        Vibration.VibratePop();
        animator.SetTrigger("Tap");
        gameManager.moneyForPerformance++;
    }
}
