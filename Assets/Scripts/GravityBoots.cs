using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GravityBoots : MonoBehaviour
{
    public playerController myPC;
    public bool bootsAreActive;

    public float bootsCD;
    public TextMeshPro bootsCDtextUI;
    public GameObject bootsCDtext;

    [SerializeField] float longueurRayon;

    void Start()
    {

    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longueurRayon);
        Color color = Color.red;
        if (hit)
        {
            color = Color.green;
            Debug.Log("Rayon touche : " + hit.collider.name);

            if (Input.GetKeyDown(KeyCode.E))
            {
                bootsAreActive = !bootsAreActive;
                ActiveBoots(bootsAreActive);
            }
        } else
        {
            color = Color.red;
        }
        Debug.DrawRay(transform.position, Vector2.down * longueurRayon, color, 0f);
    }

    void ActiveBoots(bool Bool)
    {
        if (Bool)
        {
           //myPC.gameObject.GetComponent<Transform>().position
        } else
        {
            
        }
    }
}
