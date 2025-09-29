using UnityEngine;

public class superDinoMove : MonoBehaviour
{
    public float MoveSpeed = 9;
    public Rigidbody2D rb;
    public bool movingleft = true;
    private scoreControl logic;
    public AudioSource audioData;

    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<scoreControl>();
        audioData = GetComponent<AudioSource>();
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

    public void DinoWin()
    {
        logic.superLoseScore();
        audioData.PlayOneShot(audioData.clip);
        Destroy(transform.parent.gameObject);
    }
    public void playSound()
    {
        audioData.PlayOneShot(audioData.clip);
    }
}
