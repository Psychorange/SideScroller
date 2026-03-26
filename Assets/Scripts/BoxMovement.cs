using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Transform player;
    private float distance;
    public bool shouldmove;

    public void LaunchMovement()
    {
        distance = Vector2.Distance(transform.position,player.position);
        shouldmove = true;
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
            var transPos = Camera.main.ScreenToWorldPoint(new Vector3 (mouse.x, mouse.y,Camera.main.farClipPlane));
            var transTransPos = new Vector3 (transPos.x, transPos.y, player.position.z);
            var pos =  player.position + (transTransPos-player.position).normalized*distance;
            body.MovePosition(pos);
        }
    }
}




//prof goat