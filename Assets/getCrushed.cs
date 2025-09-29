using UnityEngine;

public class getCrushed : MonoBehaviour
{
    private scoreControl logic;
    public AudioSource audioDats;
    public superDinoMove movi;
    public sound scriptsound;

    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<scoreControl>();
        audioDats = GetComponent<AudioSource>();
        scriptsound = GetComponent<sound>();
    }

    public void playerVictory()
    {
        Transform parent = transform.parent;
        Transform loseCollider = parent.Find("LoseCollider");
        Destroy(loseCollider.gameObject);
        logic.gainScore();
        audioDats.PlayOneShot(audioDats.clip);
        Destroy(transform.parent.parent.gameObject, 0.1f);
    }

    public void superPlayerVictory()
    {
        Transform parent = transform.parent;
        Transform loseCollider = parent.Find("LoseCollider");
        Destroy(loseCollider.gameObject);
        logic.superGainScore();
        audioDats.PlayOneShot(audioDats.clip);
        Destroy(transform.parent.parent.gameObject, 0.1f);
    }
}
