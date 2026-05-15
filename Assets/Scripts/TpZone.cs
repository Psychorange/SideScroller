using UnityEngine;

public class TpZone : MonoBehaviour
{
    [SerializeField] Transform nextTpZone;
    [SerializeField] GameObject cameraNextRoom;
    [SerializeField] GameObject cameraLastRoom;

    public newGravityManager gravityRoom;
    public bool thereIsGravity;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerController>();
        if (player != null)
        {
            var playerTransform = player.gameObject.GetComponent<Transform>();
            playerTransform.position = nextTpZone.position;
            cameraLastRoom.SetActive(false);
            cameraNextRoom.SetActive(true);
        }
        var gravityScript = collision.GetComponent<newGravityManager>();
        if (gravityScript != null)
        {
            print("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var nextTpZoneScript = nextTpZone.gameObject.GetComponent<NextTpZone>();
            nextTpZoneScript.gravityRoom.ActiveGravity(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var gravityScript = collision.GetComponent<newGravityManager>();
        if (gravityScript != null)
        {
            var nextTpZoneScript = nextTpZone.gameObject.GetComponent<NextTpZone>();
            nextTpZoneScript.gravityRoom.ActiveGravity(false);
        }
    }

    public void Update()
    {
        thereIsGravity = gravityRoom.gravityActive;
    }
}
