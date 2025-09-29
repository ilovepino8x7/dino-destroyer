using UnityEngine;

public class LoseColliderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            touchPlayer tp = other.GetComponent<touchPlayer>();
            if (tp != null)
            {
                tp.playerLoss();
            }
        }
    }
}
