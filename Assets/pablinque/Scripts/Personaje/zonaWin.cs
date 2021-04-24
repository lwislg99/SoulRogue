using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zonaWin : MonoBehaviour
{
    public Player playerI;
    public GameObject agujero;
    public bool yaTienes30=false;
    // Start is called before the first frame update
    void Start()
    {
        playerI = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerI.numeroMuertes >= 30&&yaTienes30==false)
        {
            Instantiate(agujero, this.transform);
            yaTienes30 = true;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (playerI.numeroMuertes >= 30)
        {
            
            SceneManager.LoadScene("MainMenu");
        }
    }
}
