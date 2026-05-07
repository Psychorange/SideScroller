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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "box")
        {
            playerController.isGround = false;
        }
    }
}
