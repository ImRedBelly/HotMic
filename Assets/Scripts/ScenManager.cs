using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
}
