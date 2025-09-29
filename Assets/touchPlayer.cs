using UnityEngine;

public class touchPlayer : MonoBehaviour
{
    private scoreControl logic;
    public AudioSource audioDats;
  public sound scriptsound;

  void Start()
  {
    logic = GameObject.Find("LogicManager").GetComponent<scoreControl>();
    audioDats = GetComponent<AudioSource>();
    scriptsound = GetComponent<sound>();
    }

    public void playerLoss()
    {
        logic.loseScore();
        scriptsound.play();
        audioDats.PlayOneShot(audioDats.clip);
        Destroy(transform.root.gameObject, 0.1f);
    }
}
