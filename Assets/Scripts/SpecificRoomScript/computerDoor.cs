using UnityEngine;

public class computerDoor : MonoBehaviour
{
    [SerializeField] Transform door;
    public bool doorOpen;

    public void OpenDoor(bool Bool)
    {
        doorOpen = Bool;
        if (doorOpen)
        {
            door.position = new Vector2(door.position.x, door.position.y + 3f);
        } else
        {
            door.position = new Vector2(door.position.x, door.position.y - 3f);
        }
    }
}
