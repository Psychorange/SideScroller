using UnityEngine;

public class doorCover : MonoBehaviour
{
    [SerializeField]
    private int sequence;
    [SerializeField]
    private BoxCollider2D mouseCollider;
    [SerializeField]
    private Transform shoot;

    public bool launchSequence;
    public playerController myPC;
    public BoxMovement Grille;

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
                    if (sequence > 15)
                    {
                        Destroy(gameObject);
                        BoxMovement GrilleIns = Instantiate(Grille,transform.position,transform.rotation);
                        GrilleIns.LaunchMovement(shoot);
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



        // IA (°-°') :
        if (myPC.imobilise)
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
                Cursor.lockState = CursorLockMode.None;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                // Force la position
                Cursor.lockState = CursorLockMode.None;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Cursor.lockState = CursorLockMode.Confined;

                // API Windows uniquement :
                // Unity ne permet pas directement SetMousePosition, donc :
                // Utiliser InputSystem :
                // Mouse.current.WarpCursorPosition(clampedScreen);
                #if ENABLE_INPUT_SYSTEM
                UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(clampedScreen);
                #endif
            }
        }
    }
}
