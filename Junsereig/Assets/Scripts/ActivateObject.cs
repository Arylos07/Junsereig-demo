using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject target;
    public bool isUI;

    public void ToggleObject(bool value)
    {
        target.SetActive(value);
        if (isUI)
        {
            JunsereigCamera.canZoom = false;
        }
    }
}
