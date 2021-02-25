using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrb : MonoBehaviour
{
    public GameManagerScript GMS;

    private void OnTriggerEnter(Collider other)
    {
        GMS.HealDamage();
    }
}
