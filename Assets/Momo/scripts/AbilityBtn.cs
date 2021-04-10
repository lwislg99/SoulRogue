 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBtn : MonoBehaviour
{
    public string skillName;

    float cooldown;
    // tiempo de carga dash
    public Image cdlmg;

    public Player playerI;
    public bool nem;

    private void Start()
    {
        playerI = FindObjectOfType<Player>();
    }

    public void Update()
    {
        /*if (playerI.Dash == true)
        {
            if (nem == false)
            {
                playerI.delayDash = 3;
                nem = true;
            }
            cooldown += Time.deltaTime;
            cdlmg.fillAmount = cooldown / playerI.delayDash;

            if (cooldown >= playerI.delayDash)
            {
                playerI.Dash = false;
                nem = false;

            }

        }*/
    }

    /*IEnumerator CoolDown()
    {
        cooldown = 0;

        Debug.Log("entro");

        cooldown += Time.deltaTime;
            cdlmg.fillAmount = cooldown / playerI.delayDash;

            if(cooldown >= playerI.delayDash)
            {
                empiezaAnimacion = false;
                StopCoroutine("CoolDown");

            }
            
            yield return null;
        
    }*/
}
