using UnityEngine;

public class NextTpZone : MonoBehaviour
{
    [SerializeField] TpZone tpZone;

    public newGravityManager gravityRoom;
    public bool thereIsGravity;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var gravityScript = collision.GetComponent<newGravityManager>();
        if (gravityScript != null)
        {
            tpZone.gravityRoom.ActiveGravity(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var gravityScript = collision.GetComponent<newGravityManager>();
        if (gravityScript != null)
        {
            tpZone.gravityRoom.ActiveGravity(false);
        }
    }

    public void Update()
    {
        thereIsGravity = gravityRoom.gravityActive;
    }
}
