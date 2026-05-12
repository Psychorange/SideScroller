using UnityEngine;

public class LadderScript : MonoBehaviour
{
    [SerializeField] playerController myPC;
    [SerializeField] float climpSpeed;
    public bool airLadder;
    public bool canMooveDown;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();

        if (player != null)
        {
            myPC = player;
            myPC.isOnLadder = true;
            myPC.jinf = 0;

            var playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocityY = 0;
                playerRb.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();

        if (player != null)
        {
            myPC.isOnLadder = false;
            myPC = null;

            var playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    public void FixedUpdate()
    {
        if (myPC != null)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                myPC.transform.position = new Vector2(myPC.transform.position.x, myPC.transform.position.y + climpSpeed);
            }

            if (Input.GetKey(KeyCode.S) && canMooveDown)
            {
                myPC.transform.position = new Vector2(myPC.transform.position.x, myPC.transform.position.y - climpSpeed);
            }
        }
    }
}
