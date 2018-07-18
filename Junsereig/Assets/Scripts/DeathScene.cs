using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScene : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().AdjustHealth(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().maxHealth);
	}
}
