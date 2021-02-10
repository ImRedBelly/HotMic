using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    int tutorInteger;
    private void Start()
    {
        tutorInteger = PlayerPrefs.GetInt(TutorManager.imTutor);
    }
    public void GameStart()
    {
        if(tutorInteger == 0)
        {
            SceneManager.LoadScene(3);
        }
        if(tutorInteger == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Restart() // загружает активную сцену
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
