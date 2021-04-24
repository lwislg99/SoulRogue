using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zonaWin : MonoBehaviour
{
    public Player playerI;
    public GameObject agujero;
    // Start is called before the first frame update
    void Start()
    {
        playerI = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (playerI.numeroMuertes >= 30)
        {
            Instantiate(agujero, this.transform);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
