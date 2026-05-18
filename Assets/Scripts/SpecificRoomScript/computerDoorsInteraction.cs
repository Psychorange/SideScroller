using UnityEngine;

public class computerDoorsInteraction : MonoBehaviour
{
    [SerializeField] computerON computerON;
    [SerializeField] bool isActivated;
    [SerializeField] SpriteRenderer mySprite;
    [SerializeField] computerDoor computerDoor1;
    [SerializeField] computerDoor computerDoor2;
    [SerializeField] SpriteRenderer virtualDoor;
    [SerializeField] computerDoorsInteraction otherComputerDoorInteraction;

    [SerializeField] doorScript doorA;
    [SerializeField] doorScript doorB;

    public void ActiveDoors()
    {
        if (computerON.computerIsOn)
        { 
            isActivated = !isActivated;
            if (isActivated)
            {
                computerDoor1.OpenDoor(true);
                computerDoor2.OpenDoor(true);

                doorA.OpenDoor(true);
                doorB.OpenDoor(true);
            } else
            {
                if (!otherComputerDoorInteraction.isActivated)
                {
                    otherComputerDoorInteraction.ActiveDoors();
                }
                computerDoor1.OpenDoor(false);
                computerDoor2.OpenDoor(false);
                
                doorA.OpenDoor(false);
                doorB.OpenDoor(false);  
            }
        }
    }

    void Update()
    {
        if (isActivated)
        {
            mySprite.color = new Color(1f, 0.8f, 1f);
            virtualDoor.enabled = false;
        } else
        {
            mySprite.color = new Color(0.4f, 0.3f, 0.4f);
            virtualDoor.enabled = true;
        }
    }
}
