using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    public Player playeri;

    public float proyectilspeed = 10;
    public float proyectilDaño = 2;

    public GameObject visualDisparo;

    float temporizadorVida=5;
    public TiemblaCamara TiemblaCamaraI;

    void Start()
    {
        
        playeri = FindObjectOfType<Player>();

        transform.right = playeri.transform.position - transform.position;
        visualDisparo.SetActive(true);
        TiemblaCamaraI = FindObjectOfType<TiemblaCamara>();
    }

    // Update is called once per frame
    void Update()
    {
        if (temporizadorVida>=0)
        {
            temporizadorVida -= Time.deltaTime;
        }

        
        transform.Translate(Vector2.right * proyectilspeed * Time.deltaTime);
        visualDisparo.transform.position = this.transform.position;
        visualDisparo.transform.rotation = new Quaternion(0, 0, 0, 0);

        if(temporizadorVida<=0)
        {
            Destroy(this.gameObject);
            visualDisparo.SetActive(false);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        //other.gameObject.CompareTag("areaDaño")
        if (other.tag == "Player")
        {
            TiemblaCamaraI.CamTiembla();
            playeri.vida -= proyectilDaño;
            Destroy(this.gameObject);
            visualDisparo.SetActive(false);
        }
        if(other.tag == "pared")
        {
            Destroy(this.gameObject);
        }
        



    }

}

