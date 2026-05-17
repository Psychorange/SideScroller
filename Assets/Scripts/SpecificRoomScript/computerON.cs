using UnityEngine;

public class computerON : MonoBehaviour
{
    [SerializeField] SpriteRenderer mySprite;
    [SerializeField] computerDoorsInteraction computerDoorInteraction1;
    [SerializeField] computerDoorsInteraction computerDoorInteraction2;
    public bool computerIsOn;

    public void ComputerON()
    {
        mySprite.color = new Color(1f, 1f, 1f);
        computerIsOn = true;

        computerDoorInteraction1.ActiveDoors();
        computerDoorInteraction2.ActiveDoors();
    }
}
