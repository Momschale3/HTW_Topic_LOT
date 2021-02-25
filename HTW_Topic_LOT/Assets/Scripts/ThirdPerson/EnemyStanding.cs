using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStanding : MonoBehaviour
{

    public GameManagerScript GMS;

    public float EnemyHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GMS.TakeDamage();
        }

        if(other.CompareTag("Weapon"))
        {
            EnemyGetsDamage();
        }
    }


    private void Update()
    {
        
    }

    public void EnemyGetsDamage()
    {
        EnemyHealth -= 50f;
        if(EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
