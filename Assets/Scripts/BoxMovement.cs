using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Transform shoot;
    [SerializeField]
    private float maxObjectLinearVelocityY;
    [SerializeField]
    private BoxCollider2D hitBox;

    public bool gravityActive;

    private float distance;
    public bool shouldmove;

    [SerializeField]
    private float velocityInWeightlessness;

    public void LaunchMovement()
    {
        distance = Vector2.Distance(transform.position, shoot.position);
        shouldmove = true;

        body.linearVelocityX = 0;
        body.linearVelocityY = 0;
        body.freezeRotation = true;
    }

    public void BoxInWeightlessness()
    {
        body.linearVelocityY = velocityInWeightlessness;
    }

    public void FixedUpdate()
    {
        if (gravityActive)
        {
            if (body.linearVelocityY <= maxObjectLinearVelocityY)
            {
                body.linearVelocityY = maxObjectLinearVelocityY;
            }
        }

        if (!shouldmove) 
        {
            return;
        }
        if (Input.GetMouseButton(1))
        {
            var mouse = Input.mousePosition;
            var transPos = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, Camera.main.farClipPlane));
            var transTransPos = new Vector3(transPos.x, transPos.y, shoot.position.z);
            var pos = shoot.position + (transTransPos - shoot.position).normalized * distance;
            body.MovePosition(pos);

            if (Mathf.Abs(Vector2.Distance(transform.position, shoot.position) - distance) >= 0.5f)
            {
                distance = Vector2.Distance(transform.position, shoot.position);
            }
        }
        else
        {
            body.freezeRotation = false;
            shouldmove = false;
        }
    }



    // IA :
    void Update()
    {
        if (shouldmove)
        {
            // Position souris → monde
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;

            // Limites du collider
            Bounds b = hitBox.bounds;

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