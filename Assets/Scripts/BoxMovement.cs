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

            if (Mathf.Abs(Vector2.Distance(transform.position, shoot.position) - distance) <= 0.5f)
            {
                print("la distance ne bouge pas");
            } else
            {
                distance = Vector2.Distance(transform.position, shoot.position);
                print ("la distance CHANGE");
            }
        }
        else
        {
            body.freezeRotation = false;
            shouldmove = false;
        }
    }
}