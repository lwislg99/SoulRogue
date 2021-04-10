using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRoom : MonoBehaviour
{

    

    //1 - bottom door
    //2 - top door
    //3 - right door
    //4 - left door

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && spawned==false)
        {
            if (other.GetComponent<RoomSpawner>().openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRoomsSpecial.Length);
                Instantiate(templates.bottomRoomsSpecial[rand], transform.position, templates.bottomRoomsSpecial[rand].transform.rotation);
            }
            if (other.GetComponent<RoomSpawner>().openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRoomsSpecial.Length);
                Instantiate(templates.topRoomsSpecial[rand], transform.position, templates.topRoomsSpecial[rand].transform.rotation);
            }
            if (other.GetComponent<RoomSpawner>().openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRoomsSpecial.Length);
                Instantiate(templates.leftRoomsSpecial[rand], transform.position, templates.leftRoomsSpecial[rand].transform.rotation);
            }
            if (other.GetComponent<RoomSpawner>().openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRoomsSpecial.Length);
                Instantiate(templates.rightRoomsSpecial[rand], transform.position, templates.rightRoomsSpecial[rand].transform.rotation);
            }
            Destroy(gameObject);

        }
    }
    
}
