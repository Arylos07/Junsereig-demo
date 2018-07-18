using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySkills : MonoBehaviour
{
    public GameObject SkillsPanel;
    public GameObject InventoryPanel;
    public GameObject Equipment;
    public GameObject OverallSkills;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("DisplaySkills") && SkillsPanel.activeSelf == false)
        {
            SkillsPanel.SetActive(true);
            OverallSkills.GetComponent<OverallSkill>().UpdateSkills();
        }
        else if(Input.GetButtonDown("DisplaySkills") && SkillsPanel.activeSelf == true)
        {
            SkillsPanel.SetActive(false);
        }

        if (Input.GetButtonDown("DisplayEquipment") && Equipment.activeSelf == false)
        {
            Equipment.SetActive(true);
        }
        else if (Input.GetButtonDown("DisplayEquipment") && Equipment.activeSelf == true)
        {
            Equipment.SetActive(false);
        }
    }
}
