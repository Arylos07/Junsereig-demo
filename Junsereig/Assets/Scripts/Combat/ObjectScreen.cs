using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScreen : MonoBehaviour
{
    public GameObject EnemyScreen;
    public GameObject Target;
    public Text Name;
    public Text Type;
    public Text Desc;

    public void SelectTarget(GameObject target, string TargetName, string TargetType, string TargetDesc)
    {
        Target = target;
        Name.text = TargetName;
        Type.text = TargetType;
        Desc.text = TargetDesc;
    }

	// Update is called once per frame
	void Update ()
    {
        if(EnemyScreen.activeSelf == true)
        {
            Target = null;
            gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Target = null;
            gameObject.SetActive(false);
        }
	}
}
