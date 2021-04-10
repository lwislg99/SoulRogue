using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antorcha : MonoBehaviour
{
    public habitacion habitacionI;


    // Start is called before the first frame update
    void Start()
    {
        //habitacionI = GameObject.Find("habitacion").GetComponent<habitacion>();
        habitacionI = GetComponentInParent<habitacion>();
    }

    // Update is called once per frame
    void Update()
    {
        if(habitacionI.encenderAntorcha==true)
        {
            Debug.Log("antorchaEncendida");
        }
    }
    
}
