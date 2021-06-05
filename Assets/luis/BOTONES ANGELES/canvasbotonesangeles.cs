using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasbotonesangeles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject texto;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        texto.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        texto.SetActive(false);
    }
}

