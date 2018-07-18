using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public CombatStats combatStats;
    public bool canAttack;
    public float autoAttackCooldown;    //attack delay
    public float autoAttackCurTime;
    public float AttackSpeed = 0f;
    public bool inRange = false;

    // Use this for initialization
    void Start ()
    {
        CalculateAttackSpeed(0);
	}
	
    /// <summary>
    /// Calculates a new attack speed. 
    /// </summary>
    /// <param name="value">Decrease to attack cooldown (- to increase rate, + to decrease rate). </param>
    public void CalculateAttackSpeed(float value)
    {
        autoAttackCooldown += value;

        AttackSpeed = (1 / autoAttackCooldown);
        combatStats.AttackSpeed = AttackSpeed;
        autoAttackCurTime = 0;
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Block"))
        {
            if(canAttack == false)
            {
                combatStats.ActivateWeapons();
            }
        }

        if (Input.GetButtonDown("Weapons"))
        {
            if(canAttack == true)
            {
                combatStats.DeactivateWeapons();
            }
            else if(canAttack == false)
            {
                combatStats.ActivateWeapons();
            }
        }


        if (autoAttackCurTime < autoAttackCooldown)
        {
            autoAttackCurTime += Time.deltaTime;
        }

        if (canAttack)
        {
            if (Input.GetButtonDown("Attack") || Input.GetAxisRaw("Attack") > 0)
            {
                if(autoAttackCurTime > autoAttackCooldown && inRange == true)
                {
                    combatStats.BasicAttack();
                    autoAttackCurTime = 0;
                }
            }
        }
	}
}
