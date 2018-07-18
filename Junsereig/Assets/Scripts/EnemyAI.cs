using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject PlayerTarget;
    public CombatStats combatStats;
    public EnemyRange range;
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public bool canMove = true;
    public bool aggro;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

 //   // Use this for initialization
 //   void Start ()
 //   {
 //       GameObject go = GameObject.FindGameObjectWithTag("Player");

 //       target = go.transform;
	//}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            Debug.DrawLine(target.position, myTransform.position, Color.red);

            //Look at target
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }

        if (canMove == true && range.inRange == false && target != null)
        {
            //Move towards target
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }

	}

    public void SetTarget(GameObject targetObject)
    {
        PlayerTarget = targetObject;
        target = PlayerTarget.transform;
        combatStats.AssignTarget(targetObject);
        combatStats.CalculateHitChance();
    }

    public void EnteredTrigger(Collider other)
    {
        if(other.tag == "Player" && aggro == true)
        {
            PlayerTarget = other.gameObject;
            target = PlayerTarget.transform;
            combatStats.AssignTarget(other.gameObject);
        }
    }

    public void ExitTrigger(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerTarget = null;
            target = null;
        }
    }
}
