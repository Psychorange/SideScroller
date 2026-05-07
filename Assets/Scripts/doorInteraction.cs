using UnityEngine;

public class doorInteraction : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer interactionSprite;
    [SerializeField]
    private bool activeDoor;

    public void tempActive()
    {
        activeDoor = !activeDoor;

        if (activeDoor)
        {
            interactionSprite.color = new Color(0f, 1f, 1f);
        }
        else
        {
            interactionSprite.color = new Color(0f, 0f, 0f);
        }
    }
}
