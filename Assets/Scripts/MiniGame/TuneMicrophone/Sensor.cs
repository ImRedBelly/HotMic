using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public BoxCollider2D collider;
    TuneMicrophone tuneMicrophone;
    void Start()
    {
        tuneMicrophone = FindObjectOfType<TuneMicrophone>();
        OffCollider();
    }
    public void OffCollider()
    {
        collider.enabled = false;
    }
    public void OnCollider()
    {
        collider.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Green"));
        {
            tuneMicrophone.trueButton += 1;
        }
    }
}
