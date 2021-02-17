using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    bool isMuted = false;

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void Mute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
