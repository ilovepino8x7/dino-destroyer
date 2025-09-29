using Unity.VisualScripting;
using UnityEngine;

public class beamMove : MonoBehaviour
{
    private bool hasDino = false;
    public bool upward = false;
    private bool offScreen = false;
    public int moveSpeed = 3;
    public GameObject dinosaur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dinosaur = transform.parent.gameObject;
    }

    // Update is called once per frame                     
    // Beam already moves with the Dino as it is a child [:)]
    void Update()
    {
        if (upward == true && offScreen == false)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
            dinosaur.transform.position = transform.position;
        }
        if (offScreen == true)
        {
            Destroy(transform.parent.gameObject);
        }
        transform.rotation = Quaternion.identity;
    }

    // Function to move down and grab the Dino
    public void grabDino()
    {
        // Grabbing Dino
        if (hasDino == false)
        {
            transform.position = dinosaur.transform.position;
        }
        upward = true;
        dinosaur.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        dinosaur.GetComponent<Rigidbody2D>().angularVelocity = 0;


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Dino")
        {
            hasDino = true;
        }
        else if (collision.gameObject.name == "Mark")
        {
            offScreen = true;
        }
    
    }
}
