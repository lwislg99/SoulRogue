using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numerosmuertesenemigos : MonoBehaviour
{
    
    public Player PlayerI;
    public Text textoNumero;
    // Start is called before the first frame update
    void Start()
    {
        PlayerI = FindObjectOfType<Player>();
        textoNumero.text = "0/30";
    }

    // Update is called once per frame
    void Update()
    {
        textoNumero.text = PlayerI.numeroMuertes.ToString()+"/30";
        if (PlayerI.numeroMuertes >= 30)
        {
            textoNumero.color = Color.red;
        }
    }
}

