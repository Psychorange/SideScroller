using UnityEngine;

public class TempGravityActivation : MonoBehaviour
{
    public GravityManager gravityManager;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!gravityManager.gravityIsActive)
            {
                gravityManager.gravity.SetActive(true);
                gravityManager.gravityIsActive = true;
            }
            else
            {
                gravityManager.gravity.SetActive(false);
                gravityManager.gravityIsActive = false;
            }
        }
    }
}
