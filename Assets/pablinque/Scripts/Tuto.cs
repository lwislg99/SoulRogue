using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour
{
    public Canvas CanvasTutoTexto;

    private void Start()
    {
        CanvasTutoTexto = GetComponentInChildren<Canvas>();
        Desactivar();
    }


    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Activar();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Desactivar();
        }
    }
    public void Activar()
    {
        CanvasTutoTexto.enabled = true;
    }
    public void Desactivar()
    {
        CanvasTutoTexto.enabled = false;
    }
}
