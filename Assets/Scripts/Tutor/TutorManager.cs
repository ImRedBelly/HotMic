using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorManager : MonoBehaviour
{
    public static TutorManager instance;
    public static string imTutor = "Tutor";
    public int boolInteger = 0;


    private void Start()
    {
        //Delet();
        if (instance == null)
            instance = this;

        else if (instance == this)
            Destroy(gameObject);
    }
    public void SaveExperience(int boolInteger)
    {
        PlayerPrefs.SetInt(imTutor, boolInteger);
    }
    void Delet()
    {
        PlayerPrefs.DeleteKey(imTutor);
    }
}
