using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class barraVida : MonoBehaviour
{
    
    public Enemigo1 Enemigo1I;
    public Enemigo2 Enemigo2I;
    public Enemigo3 Enemigo3I;
    public Enemigo4 Enemigo4I;
    public Enemigo5 Enemigo5I;
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
        if(Enemigo1I==null&&Enemigo2I==null&&Enemigo3I==null)
        {
            Enemigo4I= GetComponentInParent<Enemigo4>();
        }
        if (Enemigo1I == null && Enemigo2I == null && Enemigo3I == null&&Enemigo4I==null)
        {
            Enemigo5I = GetComponentInParent<Enemigo5>();
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
        else if(Enemigo3I!=null)
        {
            x = Enemigo3I.vidae / Enemigo3I.vidaeMax;
            transform.localScale = new Vector3(x, 1, 1);
        }
        else if(Enemigo4I!=null)
        {
            x = Enemigo4I.vidae / Enemigo4I.vidaeMax;
            transform.localScale = new Vector3(x, 1, 1);
        }
        else
        {
            x = Enemigo5I.vidae / Enemigo5I.vidaeMax;
            transform.localScale = new Vector3(x, 1, 1);
        }
    }

}
