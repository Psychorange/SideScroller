using UnityEngine;

public class ChronoScript : MonoBehaviour
{
    public static ChronoScript instance;
    public float chronoTime;

    void Update()
    {
        chronoTime += Time.deltaTime;
        if (chronoTime >= 300f)
        {
            print("you loose");
        }
    }
}
