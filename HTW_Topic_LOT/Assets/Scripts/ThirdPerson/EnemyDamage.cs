using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameManagerScript GMS;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyWeapon")
        {
            GMS.TakeDamage();
        }
    }
}
