using UnityEngine;
using System.Collections;

public class SpawnerSmile : MonoBehaviour
{
    public GameObject[] smile;
    void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.65f);
            float posX = Random.Range(-2.0f, 2.0f);
            int randomSmile = Random.Range(0, smile.Length);
            Instantiate(smile[randomSmile], transform.position = new Vector2(posX, -5), Quaternion.identity);

            StopAllCoroutines();
        }
    }
}
