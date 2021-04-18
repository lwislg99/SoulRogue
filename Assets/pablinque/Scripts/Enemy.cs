using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{




    public float vida = 3;
    public float coldownDa�o = 1;


    public Player PlayerI;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {

        if (coldownDa�o >= 0)
        {
            coldownDa�o -= Time.deltaTime;
            
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("areaDa�o") && coldownDa�o <= 0)
        {
            PlayerI= other.gameObject.GetComponent<Player>();
            vida -= PlayerI.dano;
            coldownDa�o = 1;
            if (PlayerI.balaDanoFuego==true)
            {
                vida -= (Time.deltaTime/2);
            }
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}

