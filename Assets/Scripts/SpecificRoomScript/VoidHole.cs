using UnityEngine;

public class voidHole : MonoBehaviour
{
    [SerializeField] newGravityManager roomGravity;
    [SerializeField] GravityTransferManager gravityManager;

    public void ActiveGravityRoomA()
    {
        gravityManager.roomConnections[0].roomAIsSource = true;

        roomGravity.ActiveGravity(true);
        roomGravity.gravityCantBeDelete = true;
    }
}
