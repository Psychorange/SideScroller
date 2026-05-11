using UnityEngine;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer spiteColor;
    public float speed;
    public float jumpforce;
    public float jumpInfluence = 1.5f;
    public float jinf = 0f;
    public LayerMask mask;
    public bool isGround, hasJumped, bootsIsActive;
    public bool gravityActive;
    public bool imobilise;
    public bool isOnMovingBox;

    void Update()
    {
        var hDirection = 0f;
        var vDirection = 0f;

        if (imobilise != true)
        {
            if (isGround)
            {
                if(!hasJumped)
                {
                    jinf = 0f;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    hDirection += -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    hDirection += 1;
                }
                if (!isOnMovingBox)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        vDirection += jumpforce;
                        hasJumped = true;
                        if (gravityActive == false)
                        {
                            jinf += jumpInfluence*hDirection;
                        } else
                        {
                            jinf = 0;
                        }
                    }
                }
            } 
            else
            {
                hasJumped = false;
                if (Input.GetKey(KeyCode.A))
                {
                    hDirection += -0.8f;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    hDirection += 0.8f;
                }
            }

        } else
        {
            jinf = 0;
        }
        rb.linearVelocity = new Vector2(hDirection * speed+jinf, rb.linearVelocityY + vDirection); //On set up la velocit� horizontal
    }

}
