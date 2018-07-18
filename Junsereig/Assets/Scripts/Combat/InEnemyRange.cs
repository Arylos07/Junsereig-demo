using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InEnemyRange : MonoBehaviour
{
    public EnemyAI ai;

    private void OnTriggerEnter(Collider other)
    {
        ai.EnteredTrigger(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ai.ExitTrigger(other);
    }
}
