using UnityEngine;

public class doorInteraction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer interactionSprite;
    [SerializeField] private doorScript doorScript;
    [SerializeField] private bool activeDoor;
    public bool isHidden;

    public void Active()
    {
        if(isHidden)
        {
            return;
        }

        activeDoor = !activeDoor;

        if (activeDoor)
        {
            doorScript.OpenDoor(activeDoor);
            interactionSprite.color = new Color(0f, 1f, 1f);
        }
        else
        {
            doorScript.OpenDoor(activeDoor);
            interactionSprite.color = new Color(0f, 0f, 0f);
        }
    }
}