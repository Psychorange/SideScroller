using UnityEngine;
using UnityEngine.InputSystem;

public class Aimenteur : MonoBehaviour
{
    [SerializeField] private BulletScript Bullet;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private SpriteRenderer actualToolSprite;

    Vector2 Direction;

    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePos - (Vector2)transform.position;
        transform.right = Direction;

        RaycastHit2D hit = Physics2D.Raycast(ShootPoint.position, ShootPoint.right,100);
        Debug.DrawRay(ShootPoint.position, ShootPoint.right*30);
        Debug.Log(hit.collider.tag);

        if (Input.GetMouseButtonDown(1))
        {
            actualToolSprite.color = new Color(255f, 255f, 255f, 255f);

            if (hit.collider.tag == "box" || hit.collider.tag == "cover")
            {
                var boxScript = hit.collider.GetComponent<BoxMovement>();
                var coverScript = hit.collider.GetComponent<doorCover>();

                if (boxScript != null)
                {
                    boxScript.LaunchMovement();
                }
                if (coverScript != null)
                {
                    coverScript.launchSequence = true;
                    print("(°-°)");
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) == false)
        {
            actualToolSprite.color = new Color(0f, 30f, 50f, 30f);
            Shoot();
        }
    }

    void Shoot()
    {
        BulletScript BulletIns = Instantiate(Bullet,ShootPoint.position,transform.rotation);
    }
    
}







//https://www.youtube.com/watch?v=JHIHXcsgJZc&t