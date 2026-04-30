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

        Ray ray = new Ray(transform.position, ShootPoint.right*30);
        Debug.DrawRay(transform.position, ShootPoint.right*30);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        BulletScript BulletIns = Instantiate(Bullet,ShootPoint.position,transform.rotation);
    }
}







//https://www.youtube.com/watch?v=JHIHXcsgJZc&t