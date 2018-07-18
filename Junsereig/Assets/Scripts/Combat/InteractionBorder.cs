using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBorder : MonoBehaviour
{
    public EnemyScreen enemyScreen;
    public ObjectScreen objectScreen;

    public GameObject Target;

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject == Target)
        {
            if (other.tag != "Enemy")
            {
                Target.GetComponent<InteractionTask>().CallTask();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Target)
        {
            enemyScreen.gameObject.SetActive(false);
            if (enemyScreen.Target != null)
            {
                enemyScreen.Target.GetComponentInChildren<EnemyObject>().HealthBar.SetActive(false);
            }
            enemyScreen.Target = null;
            objectScreen.gameObject.SetActive(false);
            objectScreen.Target = null;
            Target = null;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (enemyScreen.gameObject.activeSelf == true)
        {
            Target = enemyScreen.Target;
        }

        else if (objectScreen.gameObject.activeSelf == true)
        {
            Target = objectScreen.Target;
        }

        else
        {
            Target = null;
        }
	}
}
