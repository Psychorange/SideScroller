using UnityEngine;
using UnityEngine.InputSystem;

public class Aimenteur : MonoBehaviour
{
    [SerializeField] private BulletScript Bullet;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private SpriteRenderer actualToolSprite;

    Vector2 Direction;

    public void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePos - (Vector2)transform.position;
        transform.right = Direction;

        RaycastHit2D hit = Physics2D.Raycast(ShootPoint.position, ShootPoint.right,100);
        //Debug.DrawRay(ShootPoint.position, ShootPoint.right*30);
        //Debug.Log(hit.collider.tag);

        if (Input.GetMouseButtonDown(1))
        {
            actualToolSprite.color = new Color(0.2f, 0.2f, 0.5f);

            if (hit.collider.tag == "box" || hit.collider.tag == "cover")
            {
                var boxScript = hit.collider.GetComponent<BoxMovement>();
                var coverScript = hit.collider.GetComponent<doorCover>();

                var holeCoverScript = hit.collider.GetComponent<voidHoleCover>();
                var heavyBoxScript = hit.collider.GetComponent<heavyBox>();

                if (boxScript != null)
                {
                    boxScript.LaunchMovement(ShootPoint);
                }
                if (coverScript != null)
                {
                    coverScript.LaunchSequence(ShootPoint);
                } else if (holeCoverScript != null)
                {
                    holeCoverScript.LaunchSequence(ShootPoint);
                }
                if (heavyBoxScript != null)
                {
                    heavyBoxScript.LaunchSequence(ShootPoint);
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) == false)
        {
            actualToolSprite.color = new Color(0f, 1f, 1f);
            Shoot();
        }
    }

    void Shoot()
    {
        BulletScript BulletIns = Instantiate(Bullet,ShootPoint.position,transform.rotation);
    }
    
}







//https://www.youtube.com/watch?v=JHIHXcsgJZc&t