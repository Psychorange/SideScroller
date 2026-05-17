using UnityEngine;

public class doorInteraction : MonoBehaviour
{
    [SerializeField] SpriteRenderer interactionSprite;
    [SerializeField] doorScript doorScript;
    public bool activeDoor;
    public bool isHidden;
    public bool needButton;
    public bool Bool;

    public void Active()
    {
        if(isHidden)
        {
            return;
        }

        activeDoor = !activeDoor;

        if (activeDoor)
        {
            if (needButton)
            {
                return;
            }
            doorScript.OpenDoor(activeDoor);
            interactionSprite.color = new Color(0f, 1f, 1f);
        }
        else
        {
            doorScript.OpenDoor(activeDoor);
            interactionSprite.color = new Color(0f, 0f, 0f);

            Bool = false;
        }
    }

    void Update()
    {
        if (doorScript.doorOpen && !Bool)
        {
            activeDoor = false;
            Active();
            Bool = true;
        }
    }
}