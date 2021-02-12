using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    public Animator animator;
    private AsyncOperation loading;

    public static bool isLoad = false;

    private void Start()
    {
        instance = this;

        if (isLoad)
        {
            animator.SetTrigger("Open");
        }
    }
    public static void SwitchToScene(int index)
    {
        instance.animator.SetTrigger("Closed");
        instance.loading = SceneManager.LoadSceneAsync(index);
        instance.loading.allowSceneActivation = false;
    }

    public void OnAnimationOver()
    {
        isLoad = true;
        loading.allowSceneActivation = true;
    }
}
