using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDañoE1 : MonoBehaviour
{
    public Player playeri;

    
    

    

    public float despawn = 0.5f;


    void Start()
    {

        playeri = FindObjectOfType<Player>();

        transform.right = playeri.transform.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        despawn -= Time.deltaTime;  
        if(despawn<=0)
        {
            Destroy(this.gameObject);
        }

        
    }

    

}
