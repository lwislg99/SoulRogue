using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDañoE5 : MonoBehaviour
{
    public float muerte = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        muerte -= Time.deltaTime;
        if(muerte <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
