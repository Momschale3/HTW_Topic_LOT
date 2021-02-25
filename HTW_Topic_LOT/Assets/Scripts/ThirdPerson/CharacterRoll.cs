using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRoll : MonoBehaviour
{
    [Header("Assignements")]

    public ThirdPersonMovement TPM;

    [Header("Bool")]
    public bool RollIsReady = false;
    public bool Invincible = false;

    [Header("Float For Rolls")]

    public float RollDuration;
    public float RollSpeed;
    public float InitalCharacterSpeed;

    [Header("Float For Cooldown")]

    public float TimeCooldown = 5f;
    private float Timer;
    private float TimeNow;

    public void Start()
    {
        InitalCharacterSpeed = TPM.speed;
    }

    void Update()
    {
        TimeNow = Time.time;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {         

            if(TimeNow > Timer)
            {
                RollIsReady = true;
            }


            if (RollIsReady == true)
            {
                RollIsReady = false;
                StartCoroutine(RollMovement());
            }
        }

    }

    IEnumerator RollMovement()
    {
        Invincible = true;
        TPM.speed = RollSpeed;
        Timer = Time.time + TimeCooldown;
        yield return new WaitForSeconds(RollDuration);

        TPM.speed = InitalCharacterSpeed;
        Invincible = false;
    }

}
