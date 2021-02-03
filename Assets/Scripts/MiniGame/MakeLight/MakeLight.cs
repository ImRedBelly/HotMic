using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLight : MonoBehaviour
{
    public GameObject targetLight;
    RaycastHit2D hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        }

        if (Input.GetMouseButton(0))
        {
            if (hit.collider != null)
            {
                targetLight = hit.collider.gameObject;
                LightMove();
            }
        }
    }
    void LightMove()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        targetLight.transform.position = objPosition;
    }
}
