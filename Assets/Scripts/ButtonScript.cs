using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] int objectsInButton;
    [SerializeField] newGravityManager gravityRoom;
    [SerializeField] doorInteraction doorSwitcher;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "Player")
        {
            objectsInButton++;
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
            doorSwitcher.needButton = true;
            return;
        }
        if (objectsInButton <= 0)
        {
            doorSwitcher.needButton = true;
        } else 
        {
            doorSwitcher.needButton = false;
        }
    }
}
