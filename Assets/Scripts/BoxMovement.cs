using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] BoxCollider2D mouseCollider;
    private Transform shoot;
    [SerializeField] float maxObjectLinearVelocityY;
    [SerializeField] float velocityInWeightlessness;
    private float distance;
    public bool gravityActive;
    public bool shouldmove;
    public float speedRotate;
    [SerializeField] float initialMass;
    [SerializeField] float massWhenPlayerTouched;
    
    private void Start()
    {
        initialMass = body.mass;
        massWhenPlayerTouched = initialMass / 100f;
    }

    public void LaunchMovement(Transform shootTransfer)
    {
        shoot = shootTransfer;
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
            body.mass = initialMass;
            return;
        }

        body.mass = massWhenPlayerTouched;
        if (Input.GetKey(KeyCode.C))
        {
            body.rotation -= speedRotate;
        }
        if (Input.GetKey(KeyCode.X))
        {
            body.rotation += speedRotate;
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

    // IA (°-°') :
    void Update()
    {
        if (shouldmove)
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