using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void play()
    {
        if (audioData != null && audioData.clip != null)
        {
            audioData.enabled = true;
            audioData.PlayOneShot(audioData.clip);
        }
        else
        {
            Debug.LogWarning("AudioSource or clip is missing!");
        }
    }
}
