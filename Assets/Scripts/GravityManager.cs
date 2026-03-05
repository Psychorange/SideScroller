using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public bool gravityIsActive;
    public GameObject gravity;
    public playerController myPC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();

        collision.attachedRigidbody.gravityScale = 0.8f;
        collision.attachedRigidbody.linearDamping = 1;
        collision.attachedRigidbody.angularDamping = 1;
        if (player != null)
        {
            myPC.jumpInfluence = 0;
            myPC.speed -= 1.5f;
        }

        print("gravité changée");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();

        collision.attachedRigidbody.gravityScale = 2.5f;
        collision.attachedRigidbody.linearDamping = 0;
        collision.attachedRigidbody.angularDamping = 0.05f;
        if (player != null)
        {
            myPC.jumpInfluence = 1.5f;
            myPC.speed += 1.5f; 
        }

        print("gravité annulée");
    }

    
}
