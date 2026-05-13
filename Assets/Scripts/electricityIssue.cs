using UnityEngine;

public class electricityIssue : MonoBehaviour
{
    [SerializeField] electricityManager electricity;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var box = collision.GetComponent<BoxMovement>();
        if (box != null)
        {
            electricity.electricityRepare++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var box = collision.GetComponent<BoxMovement>();
        if (box != null)
        {
            electricity.electricityRepare--;
        }
    }
}
