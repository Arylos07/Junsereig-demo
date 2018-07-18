using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemy : Skill
{
    public Alchemy()
    {
        skillName = "Alchemy";
        minLevel = 1;
        maxLevel = 100;
        maxXP = 15000000;
        xpGoal = 0;
        curXP = 0;
        curLevel = 1;
    }

    private void Start()
    {

        if (curLevel == 1)
        {
            xpGoal = 83;
        }

        //print(Mathf.Round(Mathf.Floor(((99 - 1) + (300 * Mathf.Pow(2,((float)(99-1)/7)))))/4));
    }
}
