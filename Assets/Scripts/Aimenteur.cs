using UnityEngine;

public class Aimenteur : MonoBehaviour
{
    public BulletScript Bullet;
    public Transform ShootPoint;
    public BoxMovement box;

    Vector2 Direction;

    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePos - (Vector2)transform.position;
        FaceMouse();

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void FaceMouse()
    {
        transform.right = Direction;
    }

    void Shoot()
    {
        BulletScript BulletIns = Instantiate(Bullet,ShootPoint.position,transform.rotation);
    }
}

//https://www.youtube.com/watch?v=JHIHXcsgJZc&t