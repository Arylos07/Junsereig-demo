using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public EnemyAI ai;
    public bool inRange;
    public EnemyAttack attack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ai.PlayerTarget)
        {
            inRange = true;
            attack.enabled = true;
            attack.canAttack = true;
            attack.inRange = inRange;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == ai.PlayerTarget)
        {
            inRange = false;
            attack.enabled = false;
            attack.canAttack = false;
            attack.inRange = inRange;
        }
    }
}
