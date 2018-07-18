using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGuides : MonoBehaviour
{
    public string SkillGuideTag;

    public GameObject[] guides;
    public GameObject OverallSkillGuide;

    private int i;

	// Use this for initialization
	void Start ()
    {

	}

    public void OpenGuide(int index)
    {
        CloseGuides();
        guides[index].SetActive(true);
        GameObject.Find("Overall").GetComponent<OverallSkill>().UpdateXP(index);
        JunsereigCamera.canZoom = false;
    }
	
	public void CloseGuides()
    {
        i = 0;

        if (JunsereigCamera.canZoom != true)
        {
            JunsereigCamera.canZoom = true;
        }

        if(OverallSkillGuide.activeSelf == true)
        {
            OverallSkillGuide.SetActive(false);
        }

        foreach(GameObject go in guides)
        {
            guides[i].SetActive(false);
            i++;
        }
    }
}
