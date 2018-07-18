using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabToField : MonoBehaviour
{
    public InputField thisField;
    public InputField nextField;
    public bool defaultField;

    private void Start()
    {
        if (defaultField == true)
        {
            thisField.Select();
            thisField.ActivateInputField();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(thisField.isFocused == true)
            {
                nextField.Select();
                nextField.ActivateInputField();
            }
        }
	}
}
