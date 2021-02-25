using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [Header("Float for Player Properties")]
    public float Hearts = 100f;

    [Header("Bools for Player Properties")]
    public bool Invincible;

    [Header("Assignements")]
    public CharacterRoll CR;

    /*/
    public float HealthPoints = 2f;
    public int HealthMax;
    public int Where;
    
    [SerializeField]
    List<Image> HP;
    /*/

    public void Start()
    {


        /*/
        HealthMax = (int)HealthPoints;

        HP = new List<Image>(FindObjectsOfType<Image>());
     /*/
    }

    private void Update()
    {
        
    }
    
    public void TakeDamage()
    {
        if (Hearts >= 25 && CR.Invincible == false )
        {
            Hearts -= 25f;
        }
        /*/
        if (HealthPoints > 0)
        {
            HealthPoints--;
            HP[(int)HealthPoints].enabled = false;
        }
        /*/
    }

    public void HealDamage()
    {
        if (Hearts <= 50)
        {
            Hearts += 50f;
        }
        /*/
        if (HealthPoints < HealthMax)
        {
            HealthPoints++;
            HP[(int)HealthPoints].enabled = true;
        }
        /*/
    }

}
