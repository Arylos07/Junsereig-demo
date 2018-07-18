using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public CombatStats combatStats;
    public bool canAttack;
    public float autoAttackCooldown;    //attack delay
    public float autoAttackCurTime;
    public float AttackSpeed = 0f;
    public bool inRange = false;

    // Update is called once per frame
    void Update()
    {
        if (autoAttackCurTime < autoAttackCooldown)
        {
            autoAttackCurTime += Time.deltaTime;
        }

        if (canAttack && inRange)
        {
            if (autoAttackCurTime > autoAttackCooldown && inRange == true)
            {
                combatStats.EnemyBasicAttack();
                autoAttackCurTime = 0;
            }
        }
    }
}
