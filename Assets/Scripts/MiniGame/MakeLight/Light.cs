using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public TargetLight target;

    bool isPosition = false;
    void Update()
    {
        if (isPosition)
        {
            transform.position = target.transform.position;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);
            target.ColorAlpha();
        }
    }
}
