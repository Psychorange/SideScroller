using UnityEngine;
using UnityEngine.InputSystem;

public class Aimenteur : MonoBehaviour
{
    public BulletScript Bullet;
    public Transform ShootPoint;

    Vector2 Direction;

    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePos - (Vector2)transform.position;
        transform.right = Direction;

        RaycastHit2D hit = Physics2D.Raycast(ShootPoint.position, ShootPoint.right,100);
        Debug.DrawRay(ShootPoint.position, ShootPoint.right*30);
        Debug.Log(hit.collider.tag);

        if (hit.collider.tag == "box")
        {
            print("box en vue");

            if (Input.GetMouseButtonDown(0))
            {
                var boxScript = hit.collider.GetComponent<BoxMovement>();
                boxScript.LaunchMovement();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        BulletScript BulletIns = Instantiate(Bullet,ShootPoint.position,transform.rotation);
    }
}







//https://www.youtube.com/watch?v=JHIHXcsgJZc&t