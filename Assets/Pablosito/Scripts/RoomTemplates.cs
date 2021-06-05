using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject[] bottomRoomsClosed;
    public GameObject[] topRoomsClosed;
    public GameObject[] leftRoomsClosed;
    public GameObject[] rightRoomsClosed;

    public GameObject[] bottomRoomsSpecial;
    public GameObject[] topRoomsSpecial;
    public GameObject[] leftRoomsSpecial;
    public GameObject[] rightRoomsSpecial;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    public List<GameObject> cofres;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    public GameObject cofre;

    public GameObject[] items;
    public GameObject[] itemsTienda;
    public GameObject[] encantamientos;

    private RoomTemplates templates;
    private bool cofre1;
    private bool cofre2;
    private bool cofre3;
    private bool cofre4;
    private bool cofre5;

    GameObject sala;

    public GameObject Chek;

    bool chek;



    // Start is called before the first frame update
    void Start()
    {
        chek = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (chek == true)
        {
            sala = rooms[5].gameObject;
            Destroy(sala.gameObject);

            Instantiate(Chek, rooms[5].transform.position, Quaternion.identity);
            chek = false;
        }
    }
}
