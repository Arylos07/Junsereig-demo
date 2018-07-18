using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public CombatStats combatStats;
    public BasicAttack basicAttack;

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject == combatStats.Target)
        {
            basicAttack.inRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject == combatStats.Target)
        {
            basicAttack.inRange = false;
        }
    }
}
