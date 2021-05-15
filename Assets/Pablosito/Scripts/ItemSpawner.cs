using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    private int rand;

    public bool tienda;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);

    }
    void Spawn()
    {
        if(tienda == true)
        {
            rand = Random.Range(0, templates.itemsTienda.Length);
            Instantiate(templates.itemsTienda[rand], transform.position, templates.itemsTienda[rand].transform.rotation);
        }
        else
        {
            rand = Random.Range(0, templates.items.Length);
            Instantiate(templates.items[rand], transform.position, templates.items[rand].transform.rotation);
        }
        
    }
    void spawn()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
