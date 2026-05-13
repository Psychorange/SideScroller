using UnityEngine;

public class electricityManager : MonoBehaviour
{
    public int electricityRepare;
    public BoxCollider2D boxDanger;
    void Update()
    {
        if (electricityRepare >= 2)
        {
            boxDanger.enabled = false;
        } else
        {
            boxDanger.enabled = true;
        }
    }
}
