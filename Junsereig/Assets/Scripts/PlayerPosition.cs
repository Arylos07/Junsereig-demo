using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Transform PlayerTransform;
    public static Vector3 playerPosition;
	
	// Update is called once per frame
	void Update ()
    {
        if (SkillsLoader.SaveLoaded == false)
        {
            playerPosition = PlayerTransform.position;
        }
	}

    public void LoadPosition()
    {
        PlayerTransform.position = playerPosition;
        SkillsLoader.SaveLoaded = false;
    }
}
