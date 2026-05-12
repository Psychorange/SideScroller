using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public playerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Ground" || collision.tag =="box")
        {
            playerController.isGround = true;
        }

        if (playerController.isOnLadder)
        {
            var ladder = collision.gameObject.GetComponent<LadderScript>();
            if (ladder != null)
            {
                ladder.canMooveDown = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "box")
        {
            playerController.isGround = false;
        }

        if (playerController.isOnLadder)
        {
            var ladder = collision.gameObject.GetComponent<LadderScript>();
            if (ladder != null)
            {
                ladder.canMooveDown = false;
                if (ladder.airLadder)
                {
                    playerController.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }
}
