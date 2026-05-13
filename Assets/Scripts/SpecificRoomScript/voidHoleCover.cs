using UnityEngine;

public class voidHoleCover : MonoBehaviour
{
    [SerializeField] int sequence;
    [SerializeField] BoxCollider2D mouseCollider;
    private Transform shoot;
    [SerializeField] BoxMovement Grille;
    public bool launchSequence;
    public voidHole voidHole;
    public playerController myPC;

    public void Start()
    {
        sequence = 0;
    }

    public void LaunchSequence(Transform shootTransfer)
    {
        shoot = shootTransfer;
        launchSequence = true;
    }

    public void Update()
    {
        if (launchSequence)
        {
            if (Input.GetMouseButton(1))
            {
                myPC.imobilise = true;
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    sequence++;
                    if (sequence > 15)
                    {
                        Destroy(gameObject);
                        BoxMovement GrilleIns = Instantiate(Grille, transform.position, transform.rotation);
                        GrilleIns.LaunchMovement(shoot);

                        myPC.imobilise = false;
                        launchSequence = false;
                        if (voidHole != null)
                        {
                            voidHole.ActiveGravityRoomA();
                        }
                    }
                }
            }
            else
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
