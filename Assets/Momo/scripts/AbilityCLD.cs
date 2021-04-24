using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCLD : MonoBehaviour
{

    public float cooldown = 5;
    public Image imageCoolDown;
    bool isCoolDown;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            imageCoolDown.fillAmount = 0;
            isCoolDown = true;
        }

        if (isCoolDown)
        {
            imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;

            if (imageCoolDown.fillAmount >= 1)
            {
                
                isCoolDown = false;
            }
           
        }
    }

}
