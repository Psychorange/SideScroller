using Unity.VisualScripting;
using UnityEngine;

public class newGravityManager : MonoBehaviour
{
    public playerController myPC;

    public BoxCollider2D trigger;
    public SpriteRenderer BGsprite;
    public bool gravityActive;

    [SerializeField]
    private float forceX;
    [SerializeField]
    private float forceY;
    [SerializeField]
    private float attractionForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gravityActive = !gravityActive;
            trigger.enabled = gravityActive;
            BGsprite.enabled = gravityActive;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rb = collision.GetComponent<Rigidbody2D>();
        var boxScript = collision.GetComponent<BoxMovement>();

        if (rb != null)
        {
            print("trouve");
            rb.gravityScale /= attractionForce;

            if (collision.GetComponent<playerController>() == null && collision.GetComponent<BulletScript>() == null)
            {
                rb.gravityScale /= attractionForce*attractionForce;

                if (boxScript != null)
                {
                    boxScript.gravityActive = true;
                }

                if(boxScript.shouldmove)
                {
                    return;
                }
                rb.linearVelocityY = 0;
                var randomForceY = Random.Range(forceY, forceY + forceY / 10);
                rb.AddForce(new Vector3(Random.Range(forceX,-forceX), randomForceY));
                int signe = Random.Range(-1, 2);
                while (signe == 0)
                {
                    signe = Random.Range(-1, 2);
                }
                rb.angularVelocity = randomForceY * signe;

            } else
            {
                myPC.gravityActive = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var rb = collision.GetComponent<Rigidbody2D>();
        var boxScript = collision.GetComponent<BoxMovement>();

        if (rb != null)
        {
            rb.gravityScale *= attractionForce;
            if (collision.GetComponent<playerController>() == null)
            {
                rb.gravityScale *= attractionForce*attractionForce;

                if (boxScript != null)
                {
                    boxScript.gravityActive = false;
                }
                
                if(boxScript.shouldmove == false)
                {
                    rb.AddForce(new Vector3(0, Random.Range(forceX*10, (forceX + forceX / 10)*10)));
                }
            } else
            {
                myPC.gravityActive = false;
            }
        }
    }
}





//collision.AddComponent<newGravityObject>();
//Destroy(collision.GetComponent<newGravityObject>());