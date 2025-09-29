using UnityEngine;

public class DinoMove : MonoBehaviour
{
    public float MoveSpeed = 6;
    public Rigidbody2D rb;
    public bool movingleft = true;
    private scoreControl logic;
    public AudioSource audioData;
    public sound scriptSound;

    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<scoreControl>();
        audioData = GetComponent<AudioSource>();
        scriptSound = GetComponent<sound>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        transform.position += (movingleft ? Vector3.left : Vector3.right) * MoveSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector2(movingleft ? -MoveSpeed : MoveSpeed, rb.linearVelocity.y);
        rb.angularVelocity = 0f;
        if (logic.gameObject == false)
        {
            Destroy(transform.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        movingleft = !movingleft;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    public void dinoWin()
{
    logic.loseScore();

    if (audioData != null && audioData.clip != null)
    {
        scriptSound.play();
    }

    // Optional: use the sound script (only if needed)
    // scriptSound.play();

    Destroy(transform.parent.gameObject);
}

}
