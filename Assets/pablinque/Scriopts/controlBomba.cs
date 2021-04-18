using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBomba : MonoBehaviour
{

    public float lifeTime;

    public Player PlayerI;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
        PlayerI = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);

        Instantiate(explosion,this.transform);
        Destroy(gameObject);
    }
}
