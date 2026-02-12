using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public bool gravityIsActive;
    public playerController myPC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();
        gravityIsActive = true;
        print("gravité changée");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();
        gravityIsActive = false;
        print("gravité annulée");
    }

    private void Update()
    {
        if (gravityIsActive)
        {
            myPC.rb.gravityScale = 1;
            myPC.rb.linearDamping = 1;
            myPC.rb.angularDamping = 1;
        }
        else
        {
            myPC.rb.gravityScale = 2.5f;
            myPC.rb.linearDamping = 0;
            myPC.rb.angularDamping = 0.05f;
        }
    }
}
