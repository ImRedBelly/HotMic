using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Restart() // загружает активную сцену
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
