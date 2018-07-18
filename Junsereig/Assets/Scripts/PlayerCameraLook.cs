using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraLook : MonoBehaviour
{
    public static bool MouseLook;
    private Transform ThisTransform = null;

    private void Awake()
    {
        ThisTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (MouseLook)
        {
            //Update rotation - turn to face mouse pointer
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            MousePosWorld = new Vector3(-MousePosWorld.x, 0.0f, -MousePosWorld.z);

            //Get direction to cursor
            Vector3 LookDirection = MousePosWorld - ThisTransform.position;

            //FixedUpdate rotation
            ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized, Vector3.up);
        }
    }
}
