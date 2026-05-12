using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] doorScript myDoor;
    [SerializeField] int objectsInButton;
    [SerializeField] newGravityManager gravityRoom;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "Player")
        {
            objectsInButton++;
            myDoor.OpenDoor(true);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "Player")
        {
            objectsInButton--;
        }
    }

    public void Update()
    {
        if (gravityRoom.gravityActive)
        {
            myDoor.doorOpen = false;
            return;
        }
        if (objectsInButton <= 0)
        {
            myDoor.doorOpen = false;
        } else 
        {
            myDoor.doorOpen = true;
        }
    }
}
