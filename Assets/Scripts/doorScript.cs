using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer doorSprite;
    [SerializeField] BoxCollider2D doorCollider;
    [SerializeField] bool doorOpen;
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
        if (playerInDoor)
        {
            if (doorOpen)
            {
                if (Input.GetKeyDown(KeyCode.W) && !Input.GetMouseButton(1))
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
    }

    public void OpenDoor()
    {
        doorOpen = !doorOpen;
        doorCollider.enabled = false;
        doorCollider.enabled = true;

        if (doorOpen)
        {
            doorSprite.color = new Color(0f, 1f, 1f);
        }
        else        
        {
            doorSprite.color = new Color(0f, 0f, 0f);
        }
    }
}
