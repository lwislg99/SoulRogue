using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertas : MonoBehaviour
{
    public SelecionAngeles selecionAngelesI;


    // Start is called before the first frame update
    void Start()
    {
        selecionAngelesI = FindObjectOfType<SelecionAngeles>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            selecionAngelesI.activarSeleccion();

          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            

            Destroy(this.gameObject);
        }
    }
}
