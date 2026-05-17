using UnityEngine;

public class TpZone : MonoBehaviour
{
    [SerializeField] Transform nextTpZone;
    [SerializeField] GameObject cameraNextRoom;
    [SerializeField] GameObject cameraLastRoom;

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
    }
}
