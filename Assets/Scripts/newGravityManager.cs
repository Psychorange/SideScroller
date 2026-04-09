using Unity.VisualScripting;
using UnityEngine;

public class newGravityManager : MonoBehaviour
{
    public BoxCollider2D trigger;
    public SpriteRenderer BGsprite;
    public bool gravityActive;

    [SerializeField]
    private float forceX;
    [SerializeField]
    private float forceY;

    void Update()
    {
        trigger.enabled = gravityActive;
        BGsprite.enabled = gravityActive;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gravityActive = !gravityActive;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            print("trouvé");
            rb.gravityScale /= 3;

            if (collision.GetComponent<playerController>() == null)
            {
                rb.linearVelocityY = 0;
                rb.AddForce(new Vector2(Random.Range(forceX,-forceX),Random.Range(forceY,forceY+forceY/10)));
            }
        }
    }
}