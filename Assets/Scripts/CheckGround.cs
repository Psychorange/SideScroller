using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public playerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerController.isGround = false;
    }
}
