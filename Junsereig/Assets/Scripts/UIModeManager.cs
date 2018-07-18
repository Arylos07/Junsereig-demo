using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModeManager : MonoBehaviour
{
    public static bool CameraMode;
    public static bool GetCameraMode = true;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}
}
