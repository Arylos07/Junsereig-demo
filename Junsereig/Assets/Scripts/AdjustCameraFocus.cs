using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCameraFocus : MonoBehaviour
{
    public static bool CameraFocus = false;
    public GameObject Crosshair;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            gameObject.transform.localPosition = new Vector3(0, 1, 0);
            CameraFocus = true;
            Crosshair.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            gameObject.transform.localPosition = new Vector3(0, 2, 0);
            CameraFocus = false;
            if (JunsereigCamera.PassiveMode == false)
            {
                Crosshair.SetActive(true);
            }
        }
    }
}
