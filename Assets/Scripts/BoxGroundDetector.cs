using UnityEngine;

public class BoxGroundDetector : MonoBehaviour
{
    [SerializeField] private playerController playerController;
    [SerializeField] private BoxMovement boxMovement;
    [SerializeField] private bool boxIsOnPlayer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerController = collision.gameObject.GetComponent<playerController>();
            boxIsOnPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            boxIsOnPlayer = false;
        }
    }

    void Update()
    {
        if (boxIsOnPlayer)
        {
            if (boxMovement.shouldmove)
            {
                playerController.isOnMovingBox = true;
            }
            else
            {
                playerController.isOnMovingBox = false;
            }
        }
        else
        {
            if (playerController != null)
            {
                playerController.isOnMovingBox = false;
            }
        }
    }
}
