using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EatHotDog : MonoBehaviour
{
    public AudioManager audioManager;
    public Sprite[] allHotDogs;
    public Image hotDog;
    int countHotDog;
    public AudioClip eat;
    void Start()
    {
        countHotDog = allHotDogs.Length;
    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && countHotDog > 0)
            {
                audioManager.PlaySound(eat);
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