using UnityEngine;

public class doorCover : MonoBehaviour
{
    [SerializeField]
    private int sequence;

    public bool launchSequence;
    public playerController myPC;

    public void Start()
    {
        sequence = 0;
    }

    public void Update()
    {
        if (launchSequence)
        {
            if (Input.GetMouseButton(1))
            {
                myPC.imobilise = true;
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    sequence ++;
                    if (sequence > 16)
                    {
                        Destroy(gameObject);
                        myPC.imobilise = false;
                        launchSequence = false;
                    }
                }
            } else
            {
                sequence = 0;
                myPC.imobilise = false;
                launchSequence = false;
            }
        }
    }
}
