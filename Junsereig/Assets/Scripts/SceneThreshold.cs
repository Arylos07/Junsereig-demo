using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to initiate scene transitions
public class SceneThreshold : MonoBehaviour
{
    public string Destination;
    public Vector3 Location;

    public void LoadLevel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SceneTransition>().ChangeScene(Destination, Location);
    }
}
