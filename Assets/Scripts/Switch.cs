using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] bool isActivated;
    [SerializeField] SpriteRenderer switchSprite;
    [SerializeField] SpriteRenderer machineSprite;

    public void ActivateSwitch()
    {
        isActivated = !isActivated;
        if(isActivated)
        {
            switchSprite.color = new Color(0.4f, 1f, 0.45f);
            machineSprite.color = new Color(0.4f, 1f, 0.45f);
        } else
        {
            switchSprite.color = new Color(0.8f, 0.4f, 1f);
            machineSprite.color = new Color(0.8f, 0.4f, 1f);
        }
    }
}
