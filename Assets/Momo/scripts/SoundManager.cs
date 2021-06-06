/*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerHitSound, dashSound, enemyDeathSound;
    static AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        playerDashSound = Resources.Load<AudioClip>("dash");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");

        audioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        //cambiar clip de audio 
        switch (clip)
        {
            case "dash":
                audioScr.PlayOneShot(Sound);
                    break;
        }
    }
}*/
