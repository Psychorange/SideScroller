using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [SerializeField] float attractionForce;
    [SerializeField] List<Rigidbody2D> affectedObjects = new List<Rigidbody2D>();
    [SerializeField] bool playerCame;
    [SerializeField] BoxMovement Box;
    [SerializeField] Transform boxAppear;

    void FixedUpdate()
    {
        foreach (Rigidbody2D rb in affectedObjects)
        {
            var rbScript = rb.gameObject.GetComponent<BoxMovement>(); 
            if (rbScript != null)
            {
                if (rbScript.shouldmove)
                {
                    return;
                }
            }
            Vector2 direction = (transform.position - rb.transform.position).normalized;
            rb.AddForce(direction * attractionForce);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null && !affectedObjects.Contains(rb))
        {
            affectedObjects.Add(rb);
        }
        var player = collision.GetComponent<playerController>();
        if (player != null)
        {
            if (!playerCame)
            {
                BoxMovement newBox = Instantiate(Box,boxAppear.position,transform.rotation);
                newBox.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                playerCame = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                affectedObjects.Remove(rb);
            }
        }
}
