using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public GameObject ObjectPanel;
    public string Name;
    public string Type;
    [TextArea]
    public string Desc;

    private void OnMouseDown()
    {
        if (AdjustCameraFocus.CameraFocus == false)
        {
            if (ObjectPanel != null)
            {
                ObjectPanel.GetComponent<ObjectScreen>().SelectTarget(gameObject, Name, Type, Desc);
                ObjectPanel.SetActive(true);
            }
            else if(ObjectPanel == null)
            {
                ObjectPanel = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatStats>().objectScreen;
                ObjectPanel.GetComponent<ObjectScreen>().SelectTarget(gameObject, Name, Type, Desc);
                ObjectPanel.SetActive(true);
            }
        }
    }
}
