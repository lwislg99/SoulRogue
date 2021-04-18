using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class health : MonoBehaviour
{
    
    public float currentHealth = 5;
    public float maxHeath = 5;
    public UnityEvent OnDamageTaken;
    public UnityEvent Ondead;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageTaken(float amount)
    {
        currentHealth -= amount;
        OnDamageTaken.Invoke();
        if (currentHealth <= 0)
        {
            Ondead.Invoke();
        }

    }
}
