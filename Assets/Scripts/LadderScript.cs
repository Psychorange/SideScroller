using UnityEngine;

public class LadderScript : MonoBehaviour
{
    [SerializeField] playerController myPC;
    [SerializeField] float climpSpeed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();

        if (player != null)
        {
            myPC = player;

            var playerHitBox = collision.GetComponent<BoxCollider2D>();
            if (playerHitBox != null)
            {
                //playerHitBox.enabled = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();

        if (player != null)
        {
            myPC = null;

            var playerHitBox = collision.GetComponent<BoxCollider2D>();
            if (playerHitBox != null)
            {
                //playerHitBox.enabled = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (myPC != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myPC.transform.position = new Vector2(myPC.transform.position.x, myPC.transform.position.y + climpSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                myPC.transform.position = new Vector2(myPC.transform.position.x, myPC.transform.position.y - climpSpeed);
            }
        }
    }
}
