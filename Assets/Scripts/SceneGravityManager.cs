using UnityEngine;

public class SceneGravityManager : MonoBehaviour
{
    [SerializeField] doorScript door1;
    [SerializeField] newGravityManager gravityRoom1;
    [SerializeField] doorScript door2;
    [SerializeField] newGravityManager gravityRoom2;

    public void UpdateSceneGravity()
    {
        if (gravityRoom1.gravityActive)
        {
            if(door1.doorOpen && door2.doorOpen)
            {
                if (!gravityRoom2.gravityActive)
                {
                    gravityRoom2.ActiveGravity(true);
                }
            } else
            {
                gravityRoom2.ActiveGravity(false);
            }
        }

        if (gravityRoom2.gravityActive)
        {
            if(door2.doorOpen && door1.doorOpen)
            {
                if (!gravityRoom1.gravityActive)
                {
                    gravityRoom1.ActiveGravity(true);
                }
            } else
            {
                gravityRoom1.ActiveGravity(false);
            }
        }
    }
}
