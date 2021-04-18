using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBomba : MonoBehaviour
{

    public float lifeTime;

    public Player PlayerI;

    public GameObject explosion;
    public float temporizador=0; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
        PlayerI = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(temporizador<=lifeTime-0.3f)
        {
            temporizador += Time.deltaTime;
            
        }
        else
        {

            GameObject explos = Instantiate(explosion, this.transform) as GameObject;
            
        }
        
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
