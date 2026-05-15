using UnityEngine;

public class voidHole : MonoBehaviour
{
    [SerializeField] newGravityManager roomGravity;
    public void ActiveGravityRoomA()
    {
        roomGravity.ActiveGravity(true);
        roomGravity.gravityCantBeDelete = true;
    }
}
