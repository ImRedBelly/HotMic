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
            SceneManager.LoadScene(1);
        }
        if(tutorInteger == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void SceneLoad(int index)
    {
        SceneTransition.SwitchToScene(index);
    }
    public void Restart() // загружает активную сцену
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }
}
