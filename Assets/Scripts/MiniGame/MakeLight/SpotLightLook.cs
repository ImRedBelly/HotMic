using UnityEngine;

public class SpotLightLook : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        if (target != null)
            Rotate();
    }
    void Rotate()
    {
        Vector3 spotLightPosition = transform.position;
        Vector3 lightPosition = target.transform.position;

        Vector3 direction = lightPosition - spotLightPosition;
        transform.up = -direction;
    }
}
