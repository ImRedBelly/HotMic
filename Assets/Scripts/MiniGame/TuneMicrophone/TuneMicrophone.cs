using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TuneMicrophone : MonoBehaviour
{
    public Text trueAnswer;
    public GameObject greenZone;
    public GameObject redZone;
    public GameObject sensorObject;

    GameObject cloneGreenZone;


    Sensor sensor;

    public int trueButton = 0;


    float timeButton = 1.5f;
    float nextButton;

    bool isBack = true;
    bool isMove = true;

    void Start()
    {
        sensor = FindObjectOfType<Sensor>();
        cloneGreenZone = Instantiate(greenZone, new Vector2(Random.Range(-2.6f, 2.6f), redZone.transform.position.y), transform.rotation);
    }

    void Update()
    {
        trueAnswer.text = trueButton + " / 3";

        if(trueButton == 3)
        {
            StartCoroutine(Win());
        }

        if (Input.GetMouseButtonDown(0) && nextButton <= 0)
        {
            nextButton = timeButton;
            StartCoroutine(StopSensor());
        }
        if(nextButton > 0)
        {
            nextButton -= Time.deltaTime;
        }



        Restart();


        MoveSensor();
    }
    void MoveSensor()
    {
        if (isMove)
        {
            if (isBack)
            {
                sensorObject.transform.Translate(Vector2.right * 5 * Time.deltaTime);
                if (sensorObject.transform.position.x > 2.5f)
                {
                    isBack = false;
                }
            }
            else
            {
                sensorObject.transform.Translate(-Vector2.right * 5 * Time.deltaTime);
                if (sensorObject.transform.position.x < -2.5f)
                {
                    isBack = true;
                }
            }
        }
    }


    void Restart()
    {
        if(trueButton == 3)
        {
            print("You Win");
            return;
        }
    }
    IEnumerator StopSensor()
    {
        isMove = false;
        sensor.OnCollider();

        yield return new WaitForSeconds(1);

        Destroy(cloneGreenZone.gameObject);

        yield return new WaitForSeconds(0.1f);

        isMove = true;
        cloneGreenZone = Instantiate(greenZone, new Vector2(Random.Range(-2.6f, 2.6f), redZone.transform.position.y), transform.rotation);
        sensor.OffCollider();
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
