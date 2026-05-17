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
        var collisionDoorScript = collision.GetComponent<doorInteraction>();
        var collisionSwitchScript = collision.GetComponent<Switch>();

        if (collisionDoorScript != null)
        {
            collisionDoorScript.Active();
        }

        if (collisionSwitchScript != null)
        {
            collisionSwitchScript.ActivateSwitch();
        }

        if (collision.GetComponent<computerON>() != null)
        {
            collision.GetComponent<computerON>().ComputerON();
        }

        if (collision.GetComponent<computerDoorsInteraction>() != null)
        {
            collision.GetComponent<computerDoorsInteraction>().ActiveDoors();
        }
        
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
