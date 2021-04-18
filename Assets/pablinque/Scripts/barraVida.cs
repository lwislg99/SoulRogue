using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class barraVida : MonoBehaviour
{
    
    public Enemigo1 Enemigo1I;
    public Enemigo2 Enemigo2I;
    public Enemigo3 Enemigo3I;
    float x;
    private void Start()
    {
        
        Enemigo1I = GetComponentInParent<Enemigo1>();
        if (Enemigo1I==null)
        {
            Enemigo2I = GetComponentInParent<Enemigo2>();
        }
        if(Enemigo1I==null&&Enemigo2I==null)
        {
            Enemigo3I = GetComponentInParent<Enemigo3>();
        }

    }
    public void UpdateHealth()
    {
        this.gameObject.SetActive(true);
        if (Enemigo1I != null)
        {
             x = Enemigo1I.vidae / Enemigo1I.vidaeMax;
            transform.localScale = new Vector3(x, 1, 1);
        }
        else if(Enemigo2I!=null)
        {
            x = Enemigo2I.vidae / Enemigo2I.vidaeMax;
            transform.localScale = new Vector3(x, 1, 1);
        }
        else
        {
            x = Enemigo3I.vidae / Enemigo3I.vidaeMax;
            transform.localScale = new Vector3(x, 1, 1);
        }
    }

}
