using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update ()
    {

        Camera camera = Camera.main;

        transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);


    }
}
