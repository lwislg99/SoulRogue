using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiemblaCamara : MonoBehaviour
{

    public Animator AniCam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CamTiembla()
    {
        AniCam.SetTrigger("Tiembla");
    }
}
