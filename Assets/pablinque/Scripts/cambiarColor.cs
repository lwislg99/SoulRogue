using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarColor : MonoBehaviour
{
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    // Update is called once per frame
    void Update()
    {
        sr.material = matWhite;
        Invoke("ResetMaterial", 0.1f);
    }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
