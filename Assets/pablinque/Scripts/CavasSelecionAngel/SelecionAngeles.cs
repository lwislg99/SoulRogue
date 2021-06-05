using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionAngeles : MonoBehaviour
{
    
    public Button[] botonesAngeles;

    public Button button1;
    public Button button2;
    public Button button3;

    int numeroRandom;

    GameObject posicion1;
    GameObject posicion2;
    GameObject posicion3;

    

    public Player PlayerI;
    // Start is called before the first frame update
    void Start()
    {
        PlayerI = FindObjectOfType<Player>();

        /*for (int i=0 ; i < botonesAngeles.Length ; i++)
        {
            botonesAngeles[i]=
        }*/
        /*botonesAngeles[0] = 
        botonesAngeles[0]= */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            activarSeleccion();
        }
    }
    public void activarSeleccion()

    {
        PlayerI.movJugadorActivado = false;

        numeroRandom = Random.Range(0, botonesAngeles.Length);
        button1 = botonesAngeles[numeroRandom];
        numeroRandom = Random.Range(0, botonesAngeles.Length);
        button2 = botonesAngeles[numeroRandom];
        numeroRandom = Random.Range(0, botonesAngeles.Length);
        button3 = botonesAngeles[numeroRandom];

        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);

        
        
        button1.gameObject.transform.position = posicion1.transform.position;
        button2.gameObject.transform.position = posicion2.transform.position;
        button3.gameObject.transform.position = posicion3.transform.position;


        
        
    }
}
