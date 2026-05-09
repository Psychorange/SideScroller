using UnityEngine;

public class doorInteraction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer interactionSprite;
    [SerializeField] private doorScript doorScript;
    [SerializeField] private bool activeDoor;
    public bool isHidden;

    public void Start()
    {
        activeDoor = false;
        isHidden = true;
    }

    public void Active()
    {
        if(isHidden)
        {
            return;
        }

        activeDoor = !activeDoor;
        if (activeDoor)
        {
            doorScript.OpenDoor();
            interactionSprite.color = new Color(0f, 1f, 1f);
        }
        else
        {
            doorScript.OpenDoor();
            interactionSprite.color = new Color(0f, 0f, 0f);
        }
    }
}
