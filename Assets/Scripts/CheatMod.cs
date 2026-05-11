using UnityEngine;

public class CheatMod : MonoBehaviour
{
    public bool cheatModeActive;
    public GameObject player;
    public newGravityManager cheatGravity;
    public float jumpForce;

    void Update()
    {
        if (cheatModeActive)
        {
            //player.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.3f, 0.35f);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                cheatGravity.ActiveGravity();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
            
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0)
            {
                player.GetComponent<playerController>().speed ++;
            }
            if (scroll < 0)
            {
                player.GetComponent<playerController>().speed --;
            }
        }
    }
}
