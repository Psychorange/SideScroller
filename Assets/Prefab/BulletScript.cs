using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Aimenteur gun;
    public GameObject mygun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            gun.TargetHit(collision.gameObject);
        }
    }
}
