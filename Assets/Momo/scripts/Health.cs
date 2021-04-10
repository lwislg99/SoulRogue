using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;



    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Player playerI;

    void Start()
    {
        playerI = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(playerI.vida < numOfHearts)
        {
            playerI.vida = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerI.vida)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
