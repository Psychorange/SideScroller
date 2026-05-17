using UnityEngine;

public class heavyBox : MonoBehaviour
{
    [SerializeField] private int sequence;
    [SerializeField] private BoxCollider2D mouseCollider;
    private Transform shoot;
    public bool launchSequence;
    public playerController myPC;

    [SerializeField] bool thisScriptActive;
    [SerializeField] BoxMovement boxMovementScript;
    [SerializeField] BoxGroundDetector boxGroundDetectorScript;
    [SerializeField] newGravityManager newGravityScript;

    public void Start()
    {
        sequence = 0;
        boxMovementScript.speedRotate = 1;
        boxMovementScript.enabled = false;
        boxGroundDetectorScript.enabled = false;
    }

    public void LaunchSequence(Transform shootTransfer)
    {
        if (!thisScriptActive)
        {
            return;
        }
        shoot = shootTransfer;
        launchSequence = true;
    }
    
    public void Update()
    {
        if (newGravityScript.gravityActive)
        {
            thisScriptActive = false;

            tag = "box";
            boxMovementScript.enabled = true;
            boxGroundDetectorScript.enabled = true;
        } else
        {
            tag = "cover";
            thisScriptActive = true;

            boxMovementScript.enabled = false;
            boxGroundDetectorScript.enabled = false;
        }
        if (!thisScriptActive)
        {
            return;
        }
        if (launchSequence)
        {
            if (Input.GetMouseButton(1))
            {
                myPC.imobilise = true;
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    sequence ++;
                }
            } else
            {
                sequence = 0;
                myPC.imobilise = false;
                launchSequence = false;
            }
        }



        // IA (°-°') :
        if (launchSequence)
        {
            // Position souris → monde
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;

            // Limites du collider
            Bounds b = mouseCollider.bounds;

            // Clamp dans les limites
            float x = Mathf.Clamp(mouseWorld.x, b.min.x, b.max.x);
            float y = Mathf.Clamp(mouseWorld.y, b.min.y, b.max.y);

            // Si la souris est sortie → on la ramène
            if (mouseWorld.x != x || mouseWorld.y != y)
            {
                Vector3 clampedWorld = new Vector3(x, y, 0);

                // Monde → écran
                Vector3 clampedScreen = Camera.main.WorldToScreenPoint(clampedWorld);

                // Repositionne la souris
                #if ENABLE_INPUT_SYSTEM
                UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(clampedScreen);
                #endif
            }
        }
    }
}
