using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelScript : MonoBehaviour
{
    public string esteAngel;
    

    public Player PlayerI;
    public SelecionAngeles SelecionAngelesI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pulsarBoton()
    {

        PlayerI = FindObjectOfType<Player>();
        PlayerI.movJugadorActivado = true;
        SelecionAngelesI = FindObjectOfType<SelecionAngeles>();


        PlayerI.angelGame = esteAngel;

        SelecionAngelesI.button1.gameObject.SetActive(false);
        SelecionAngelesI.button2.gameObject.SetActive(false);
        SelecionAngelesI.button3.gameObject.SetActive(false);

    }
}
