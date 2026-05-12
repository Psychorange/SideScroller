using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer doorSprite;
    [SerializeField] BoxCollider2D doorCollider;
    public bool doorOpen;
    [SerializeField] bool playerInDoor;
    [SerializeField] string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorOpen)
        {
            var player = collision.GetComponent<playerController>();
            if (player != null)
            {
                playerInDoor = true;
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
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        } else
        {
            doorSprite.color = new Color(0f, 0f, 0f);
        }
        
    }

    public void OpenDoor(bool Bool)
    {
        doorOpen = Bool;
        doorCollider.enabled = false;
        doorCollider.enabled = true;
    }
}
