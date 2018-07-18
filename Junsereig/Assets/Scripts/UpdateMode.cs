using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMode : MonoBehaviour
{
    public Text ModeText;

    public static void ChangeUI(bool mode)
    {
        GameObject.Find("CameraMode").GetComponent<UpdateMode>().UpdateModeUI(mode);
    }

    public static void ChangeMode(bool Passive)
    {
        JunsereigCamera.ChangeCameraMode(Passive);
    }

    public void UpdateModeUI(bool mode)
    {
        if(mode == true)
        {
            ModeText.text = "Passive Mode";
        }
        else if(mode == false)
        {
            ModeText.text = "Active Mode";
        }
    }

}
