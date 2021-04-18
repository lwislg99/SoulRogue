using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulasAtaques : MonoBehaviour
{
    public ParticleSystem particulas;
    public GameObject lugarAparicion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("areaDaño"))
        {
            GameObject.Instantiate(particulas,lugarAparicion.transform);
        }
    }
}
