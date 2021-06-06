using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class amuletoVisualMandamiento : MonoBehaviour
{
    public Player playerI;
    public bool nem;

    public Image imageCoolDown;
    bool isCoolDown;

    private void Start()
    {
        playerI = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerI.delayHabilidades <= 0)
        {
            imageCoolDown.fillAmount = 0;
            isCoolDown = true;
        }

        if (isCoolDown == true)
        {
            imageCoolDown.fillAmount += 1 / playerI.delayHabilidades * Time.deltaTime;

            if (imageCoolDown.fillAmount >= 1)
            {

                isCoolDown = false;
            }

        }
    }
}
