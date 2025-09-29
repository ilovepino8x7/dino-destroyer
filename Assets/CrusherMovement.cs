using UnityEngine;

public class CrusherMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int jumpForce = 2;
    public int moveSpeed = 2;
    public AudioSource audiodata;
    public scoreControl scoreontrol;

    void Start()
    {
        scoreontrol = GameObject.Find("LogicManager").GetComponent<scoreControl>();
    }




    void Update()
    {
        transform.rotation = Quaternion.identity;

        if (Input.GetKey(KeyCode.A) && scoreontrol.gamePlaying == true)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D)&& scoreontrol.gamePlaying == true)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f &&scoreontrol.gamePlaying == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && scoreontrol.gamePlaying == true)
        {
            audiodata.PlayOneShot(audiodata.clip);
            collision.transform.GetComponentInParent<DinoMove>().dinoWin();
        }
        else if (collision.gameObject.tag == "skibidi" && scoreontrol.gamePlaying == true)
        {
            collision.transform.GetComponentInParent<superDinoMove>().DinoWin();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        getCrushed crushed = other.GetComponent<getCrushed>();
        if (crushed != null  && scoreontrol.gamePlaying == true)
        {
            if (other.transform.GetComponentInParent<DinoMove>() != null)
            {
                crushed.playerVictory();
            }
            else if (other.transform.GetComponentInParent<superDinoMove>() != null)
            {
                crushed.superPlayerVictory();
            }
        }
    }
}
