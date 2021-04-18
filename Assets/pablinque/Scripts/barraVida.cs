using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class barraVida : MonoBehaviour
{
    public health healthI;
    private void Start()
    {
        healthI = GetComponentInParent<health>();

    }
    public void UpdateHealth()
    {
        float x = healthI.currentHealth / healthI.maxHeath;
        transform.localScale = new Vector3(x, 1, 1);
    }

}
