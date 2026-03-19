using UnityEngine;

public class Aimenteur : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;

    Vector2 Direction;

    void Start()
    {

    }

    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePos - (Vector2)transform.position;
        FaceMouse();

        if (Input.GetMouseButtonDown(0))
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
        GameObject BulletIns = Instantiate(Bullet,ShootPoint.position,Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(transform.right * BulletSpeed);
    }

    public void TargetHit(GameObject hit)
    {

    }
}

//https://www.youtube.com/watch?v=JHIHXcsgJZc&t