using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DisableNullSave : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        if(Uploader.PlayerID == 0)
        {
            gameObject.SetActive(false);
        }
	}
}
