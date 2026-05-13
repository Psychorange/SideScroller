using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer doorSprite;
    [SerializeField] BoxCollider2D doorCollider;
    public bool doorOpen;
    [SerializeField] bool playerInDoor;
    [SerializeField] bool thereIsGravity;
    [SerializeField] newGravityManager gravityRoom;
    //[SerializeField] string sceneToLoad;
    [SerializeField] Transform nextDoor;
    [SerializeField] GameObject cameraNextRoom;
    [SerializeField] GameObject cameraLastRoom;
    [SerializeField] Transform playerTransform;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorOpen)
        {
            var player = collision.GetComponent<playerController>();

            if (player != null)
            {
                playerInDoor = true;
                playerTransform = player.transform;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (doorOpen)
        {
            var player = collision.GetComponent<playerController>();

            if (player != null)
            {
                playerInDoor = false;
                playerTransform = null;
            }
        }
    }

    public void Update()
    {        
        if (doorOpen)
        {
            doorSprite.color = new Color(0f, 1f, 1f);

            if (playerInDoor)
            {
                if (Input.GetKeyDown(KeyCode.W) && !Input.GetMouseButton(1))
                {
                    //SceneManager.LoadScene(sceneToLoad);
                    playerTransform.position = nextDoor.position;
                    cameraLastRoom.SetActive(false);
                    cameraNextRoom.SetActive(true);
                }
            }
        } else
        {
            doorSprite.color = new Color(0f, 0f, 0f);
        }
        thereIsGravity = gravityRoom.gravityActive;
    }

    public void OpenDoor(bool Bool)
    {
        doorOpen = Bool;
        doorCollider.enabled = false;
        doorCollider.enabled = true;

        var nextDoorScript = nextDoor.gameObject.GetComponent<doorScript>();
        nextDoorScript.gravityRoom.gravityActive = !thereIsGravity;
        nextDoorScript.gravityRoom.ActiveGravity();
    }
}