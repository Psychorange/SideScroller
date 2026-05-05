using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Transform shoot;

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
        if (!shouldmove) 
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            var mouse = Input.mousePosition;
            var transPos = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, Camera.main.farClipPlane));
            var transTransPos = new Vector3(transPos.x, transPos.y, shoot.position.z);
            var pos = shoot.position + (transTransPos - shoot.position).normalized * distance;
            body.MovePosition(pos);
        }
        else
        {
            body.freezeRotation = false;
            shouldmove = false;
        }
    }
}