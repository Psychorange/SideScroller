using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Aimenteur gun;
    public Transform myGun;
    public Rigidbody2D body;
    public float BulletSpeed;

    public void Start()
    {
        body.AddForce(transform.right * BulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var boxScript = collision.GetComponent<BoxMovement>();
        if (boxScript != null)
        {
            boxScript.LaunchMovement();
        }
        Destroy(gameObject);
    }
}
