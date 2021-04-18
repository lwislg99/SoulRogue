using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualDisparo : MonoBehaviour
{

    public controladorBala controladorBalaI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        controladorBalaI = FindObjectOfType<controladorBala>();
        if (CompareTag("pared")) 
        {
            controladorBalaI.gameObject.SetActive(false);
            Destroy(gameObject);
            
        }
    }
}
