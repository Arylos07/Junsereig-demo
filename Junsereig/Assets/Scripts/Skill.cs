using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public int minLevel = 1;
    public int maxLevel = 100;
    public List<int> XPGoals = (new List<int>{83,174,276,388,512,650,801,969,1154,1358,1584,1833,2107,2411,2746,3115,3523,3973,4470,5018,5624,6291,7028,7842,8740,
        9730,10824,12031,13363,14833,16456,18247,20224,22406,24815,27473,30408,33648,37224,41171,45529,50339,55649,61512,67983,75127,83014,91721,101333,111945,
        123660,136594,150872,166636,184040,203254,224466,247886,273742,302288,333804,368599,407015,449428,496254,547953,605032,668051,737627,814445,866257,992895,
        1096278,1210421,1336443,1475581,1629200,1798808,1986068,2192818,2421087,2673114,2951373,3258594,3597792,3972294,4385776,4842295,5346332,5902831,6517253,
        7195629,7944614,8771558,9684577,10692629,11805606,13034431,15000000,99999999});
    public int maxXP = 15000000;
    public int xpGoal = 0;
    public int curXP = 0;
    public int curLevel = 1;

    /// <summary>
    /// Adjust XP of skill, used for adding XP through correct means. Automatically levels up if needed. To remove XP, use a negative value (will not adjust level)
    /// </summary>
    /// <param name="xp">XP (+/-) to add. Removing XP will not adjust level. Automatically levels up if needed</param>
    public void AddXP(int xp)
    {
        if (curLevel != 100)
        {
            curXP += xp;
            Debug.Log(xp + "xp added to " + skillName + ". Current XP: " + curXP);

            if (curXP >= XPGoals[curLevel - 1])
            {
                LevelUp();
            }
        }
    }

    public void LevelUp()
    {
        while (curXP >= XPGoals[curLevel - 1])
        {
            curLevel++;

            //calculate new xp difference.
            //int difference = Mathf.RoundToInt(Mathf.Floor(((curLevel - 1) + (300 * Mathf.Pow(2, ((float)(curLevel - 1) / 7))))) / 4) + (curXP - xpDiff);
        }

        Debug.Log("Congratulations! You leveled up in " + skillName + "! You are now level " + curLevel);
        if (GameObject.Find("Skills") != null)
        {
            GameObject.Find("Overall").GetComponent<OverallSkill>().UpdateSkills();
        }

        if (curLevel == 100)
        {
            xpGoal = 15000000;
            curXP = 15000000;
            Debug.Log("You have reached level 100 in " + skillName + ", the highest level possible!");
        }
        else
        {
            xpGoal = XPGoals[curLevel - 1];
            Debug.Log("New xp goal: " + XPGoals[curLevel - 1]);
        }
    }

    /// <summary>
    /// Manually set XP amount and skill level without notification. Used to adjust level/XP or loading player save file.
    /// </summary>
    /// <param name="XP">Skill XP to load. Automatically assigns level</param>
    public void SetXP(int XP)
    {
        curXP = XP;

        while (curXP >= XPGoals[curLevel - 1])
        {
            curLevel++;
        }

        if (GameObject.Find("Skills") != null)
        {
            GameObject.Find("Overall").GetComponent<OverallSkill>().UpdateSkills();
        }

        if (curLevel == 100)
        {
            xpGoal = 15000000;
            curXP = 15000000;
        }
        else
        {
            xpGoal = XPGoals[curLevel - 1];
        }
    }

}
