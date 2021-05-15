using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    
        





        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;
        public Player PlayerI;

    private void Start()
    {
        PlayerI = FindObjectOfType<Player>();
    }

    void Update()
        {
            if (PlayerI.vida > PlayerI.vidaMax)
            {
            PlayerI.vida = PlayerI.vidaMax;
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < PlayerI.vida)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }


                if (i < PlayerI.vidaMax)
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
