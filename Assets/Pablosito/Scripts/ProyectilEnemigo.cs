using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    public Player playeri;

    public float proyectilspeed = 10;
    public float proyectilDaño = 2;
    
    void Start()
    {
        playeri = FindObjectOfType<Player>();

        transform.right = playeri.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.right * proyectilspeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        //other.gameObject.CompareTag("areaDaño")
        if (other.tag == "Player")
        {

            playeri.vida -= proyectilDaño;
            Destroy(this.gameObject);
        }
        



    }

}

