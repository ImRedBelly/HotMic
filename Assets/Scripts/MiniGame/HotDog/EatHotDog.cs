using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EatHotDog : MonoBehaviour
{
    public Sprite[] allHotDogs;
    public Image hotDog;
    int countHotDog;
    void Start()
    {
        countHotDog = allHotDogs.Length;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() && countHotDog > 0)
            {
                hotDog.sprite = allHotDogs[countHotDog - 1];
                countHotDog--;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
