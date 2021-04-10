using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    public GameObject cofre;
    
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (templates.cofres.Count <= 5)
        {
            float ratio = Random.Range(0, 10);
            if (ratio <= 2)
            {
                
                Instantiate(cofre, this.transform.position, Quaternion.identity);
            }

        }
        Destroy(gameObject);
    }
    void Spawn()
    {
        
    }
}
