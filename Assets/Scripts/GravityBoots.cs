using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GravityBoots : MonoBehaviour
{
    public playerController myPC;
    public bool bootsAreActive;
    public GameObject myPCboxDetection;
    public float bootsCD;

    public TextMeshPro bootsCDtextUI;
    public GameObject bootsCDtext;

    private void Update()
    {
        if (bootsCD >= 2)
        {
            bootsCDtext.SetActive(false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                
                bootsAreActive = !bootsAreActive;
                bootsCD = 0;

                if (bootsAreActive == true)
                {
                    myPC.bootsIsActive = true;
                    myPCboxDetection.SetActive(false);
                    myPC.rb.gravityScale *= 10;
                    myPC.jinf = 0;
                }
                else
                {
                    myPC.bootsIsActive = false;
                    myPCboxDetection.SetActive(true);
                    myPC.rb.gravityScale /= 10;
                }
            }
        }
        else 
        {
            bootsCDtext.SetActive(true);
            bootsCD += Time.deltaTime;
            var bootsCDrounded = Mathf.RoundToInt(bootsCD);
            bootsCDtextUI.text = ($"{bootsCDrounded}s");
        }
    }
}
