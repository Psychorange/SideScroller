using UnityEngine;

public class CheatMod : MonoBehaviour
{
    public bool cheatModeActive;
    public GameObject player;

    void Update()
    {
        if (cheatModeActive)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                player.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
            }
            
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0)
            {
                player.GetComponent<playerController>().speed += 1f;
            }
            if (scroll < 0)
            {
                player.GetComponent<playerController>().speed -= 1f;
            }
        }
    }
}
