using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverallSkill : MonoBehaviour
{
    public Text Overall;
    public GameObject Player;
    public static int PlayerCombatRating = 0;

    //Skill icons
    public Text Vitality;
    public Text Divinity;
    public Text Blademaster;
    public Text Bowmaster;
    public Text Runemaster;
    public Text Defence;
    public Text Agility;
    public Text Cooking;
    public Text Hunting;
    public Text Alchemy;
    public Text Mining;
    public Text Smithing;
    public Text Crafting;
    public Text CombatRating;

    //Guide Texts
    //Vitality
    public Text VLevel;
    public Text VXp;
    public Text VRemaining;

    //Divinity
    public Text DivLevel;
    public Text DivXp;
    public Text DivRemaining;

    //Blademastery
    public Text B1Level;
    public Text B1Xp;
    public Text B1Remaining;

    //Bowmastery
    public Text B2Level;
    public Text B2Xp;
    public Text B2Remaining;

    //Runemastery
    public Text RLevel;
    public Text RXp;
    public Text RRemaining;

    //Defence
    public Text DLevel;
    public Text DXp;
    public Text DRemaining;

    //Agility
    public Text A1Level;
    public Text A1Xp;
    public Text A1Remaining;

    //Cooking
    public Text C1Level;
    public Text C1Xp;
    public Text C1Remaining;

    //Hunting
    public Text HLevel;
    public Text HXp;
    public Text HRemaining;

    //Alchemy
    public Text A2Level;
    public Text A2Xp;
    public Text A2Remaining;

    //Mining
    public Text MLevel;
    public Text MXp;
    public Text MRemaining;

    //Smithing
    public Text SLevel;
    public Text SXp;
    public Text SRemaining;

    //Crafting
    public Text C2Level;
    public Text C2Xp;
    public Text C2Remaining;

    public void Start()
    {
        UpdateSkills();
    }

    public void UpdateXP(int index)
    {
        if (index == 0)
        {
            VLevel.text = (Player.GetComponent<Vitality>().curLevel + "/100");
            VXp.text = ("XP: " + Player.GetComponent<Vitality>().curXP.ToString("n0"));
            VRemaining.text = ("To next level: " + (Player.GetComponent<Vitality>().xpGoal - Player.GetComponent<Vitality>().curXP).ToString("n0"));
        }
        else if(index == 1)
        {
            DivLevel.text = (Player.GetComponent<Divinity>().curLevel + "/100");
            DivXp.text = ("XP: " + Player.GetComponent<Divinity>().curXP.ToString("n0"));
            DivRemaining.text = ("To next level: " + (Player.GetComponent<Divinity>().xpGoal - Player.GetComponent<Divinity>().curXP).ToString("n0"));
        }
        else if(index == 2)
        {
            B1Level.text = (Player.GetComponent<Blademaster>().curLevel + "/100");
            B1Xp.text = ("XP: " + Player.GetComponent<Blademaster>().curXP.ToString("n0"));
            B1Remaining.text = ("To next level: " + (Player.GetComponent<Blademaster>().xpGoal - Player.GetComponent<Blademaster>().curXP).ToString("n0"));
        }
        else if(index == 3)
        {
            B2Level.text = (Player.GetComponent<Bowmaster>().curLevel + "/100");
            B2Xp.text = ("XP: " + Player.GetComponent<Bowmaster>().curXP.ToString("n0"));
            B2Remaining.text = ("To next level: " + (Player.GetComponent<Bowmaster>().xpGoal - Player.GetComponent<Bowmaster>().curXP).ToString("n0"));
        }
        else if(index == 4)
        {
            RLevel.text = (Player.GetComponent<Runemaster>().curLevel + "/100");
            RXp.text = ("XP: " + Player.GetComponent<Runemaster>().curXP.ToString("n0"));
            RRemaining.text = ("To next level: " + (Player.GetComponent<Runemaster>().xpGoal - Player.GetComponent<Runemaster>().curXP).ToString("n0"));
        }
        else if(index == 5)
        {
            DLevel.text = (Player.GetComponent<Defence>().curLevel + "/100");
            DXp.text = ("XP: " + Player.GetComponent<Defence>().curXP.ToString("n0"));
            DRemaining.text = ("To next level: " + (Player.GetComponent<Defence>().xpGoal - Player.GetComponent<Defence>().curXP).ToString("n0"));
        }
        else if(index == 6)
        {
            A1Level.text = (Player.GetComponent<Agility>().curLevel + "/100");
            A1Xp.text = ("XP: " + Player.GetComponent<Agility>().curXP.ToString("n0"));
            A1Remaining.text = ("To next level: " + (Player.GetComponent<Agility>().xpGoal - Player.GetComponent<Agility>().curXP).ToString("n0"));
        }
        else if(index == 7)
        {
            C1Level.text = (Player.GetComponent<Cooking>().curLevel + "/100");
            C1Xp.text = ("XP: " + Player.GetComponent<Cooking>().curXP.ToString("n0"));
            C1Remaining.text = ("To next level: " + (Player.GetComponent<Cooking>().xpGoal - Player.GetComponent<Cooking>().curXP).ToString("n0"));
        }
        else if(index == 8)
        {
            HLevel.text = (Player.GetComponent<Hunting>().curLevel + "/100");
            HXp.text = ("XP: " + Player.GetComponent<Hunting>().curXP.ToString("n0"));
            HRemaining.text = ("To next level: " + (Player.GetComponent<Hunting>().xpGoal - Player.GetComponent<Hunting>().curXP).ToString("n0"));
        }
        else if (index == 9)
        {
            A2Level.text = (Player.GetComponent<Alchemy>().curLevel + "/100");
            A2Xp.text = ("XP: " + Player.GetComponent<Alchemy>().curXP.ToString("n0"));
            A2Remaining.text = ("To next level: " + (Player.GetComponent<Alchemy>().xpGoal - Player.GetComponent<Alchemy>().curXP).ToString("n0"));
        }
        else if(index == 10)
        {
            MLevel.text = (Player.GetComponent<Mining>().curLevel + "/100");
            MXp.text = ("XP: " + Player.GetComponent<Mining>().curXP.ToString("n0"));
            MRemaining.text = ("To next level: " + (Player.GetComponent<Mining>().xpGoal - Player.GetComponent<Mining>().curXP).ToString("n0"));
        }
        else if(index == 11)
        {
            SLevel.text = (Player.GetComponent<Smithing>().curLevel + "/100");
            SXp.text = ("XP: " + Player.GetComponent<Smithing>().curXP.ToString("n0"));
            SRemaining.text = ("To next level: " + (Player.GetComponent<Smithing>().xpGoal - Player.GetComponent<Smithing>().curXP).ToString("n0"));
        }
        else if(index == 12)
        {
            C2Level.text = (Player.GetComponent<Crafting>().curLevel + "/100");
            C2Xp.text = ("XP: " + Player.GetComponent<Crafting>().curXP.ToString("n0"));
            C2Remaining.text = ("To next level: " + (Player.GetComponent<Crafting>().xpGoal - Player.GetComponent<Crafting>().curXP).ToString("n0"));
        }
    }

    public void UpdateSkills()
    {
        Overall.text = (Player.GetComponent<Vitality>().curLevel + Player.GetComponent<Divinity>().curLevel + Player.GetComponent<Blademaster>().curLevel + Player.GetComponent<Bowmaster>().curLevel + Player.GetComponent<Runemaster>().curLevel +
            Player.GetComponent<Defence>().curLevel + Player.GetComponent<Agility>().curLevel + Player.GetComponent<Cooking>().curLevel + Player.GetComponent<Hunting>().curLevel + Player.GetComponent<Alchemy>().curLevel + Player.GetComponent<Mining>().curLevel +
            Player.GetComponent<Smithing>().curLevel + Player.GetComponent<Crafting>().curLevel).ToString();

        PlayerCombatRating = (int)(((1.3) * Mathf.Max((Player.GetComponent<Blademaster>().curLevel * 2), (Player.GetComponent<Runemaster>().curLevel * 2), (Player.GetComponent<Bowmaster>().curLevel * 2)) + Player.GetComponent<Defence>().curLevel + Player.GetComponent<Vitality>().curLevel +
            (Player.GetComponent<Divinity>().curLevel * 0.5) + (Player.GetComponent<Hunting>().curLevel * 0.5)) / 4);

        Player.GetComponent<PlayerHealth>().CombatLevel = PlayerCombatRating;

        CombatRating.text = "Combat: " + PlayerCombatRating.ToString();

        Vitality.text = Player.GetComponent<Vitality>().curLevel.ToString();
        if (Player.GetComponent<Vitality>().curLevel == 100)
        {
            Vitality.color = Color.green;
        }

        Divinity.text = Player.GetComponent<Divinity>().curLevel.ToString();
        if(Player.GetComponent<Divinity>().curLevel == 100)
        {
            Divinity.color = Color.green;
        }

        Blademaster.text = Player.GetComponent<Blademaster>().curLevel.ToString();
        if(Player.GetComponent<Blademaster>().curLevel == 100)
        {
            Blademaster.color = Color.green;
        }

        Bowmaster.text = Player.GetComponent<Bowmaster>().curLevel.ToString();
        if(Player.GetComponent<Bowmaster>().curLevel == 100)
        {
            Bowmaster.color = Color.green;
        }

        Runemaster.text = Player.GetComponent<Runemaster>().curLevel.ToString();
        if(Player.GetComponent<Runemaster>().curLevel == 100)
        {
            Runemaster.color = Color.green;
        }

        Defence.text = Player.GetComponent<Defence>().curLevel.ToString();
        if(Player.GetComponent<Defence>().curLevel == 100)
        {
            Defence.color = Color.green;
        }

        Agility.text = Player.GetComponent<Agility>().curLevel.ToString();
        if(Player.GetComponent<Agility>().curLevel == 100)
        {
            Agility.color = Color.green;
        }

        Cooking.text = Player.GetComponent<Cooking>().curLevel.ToString();
        if(Player.GetComponent<Cooking>().curLevel == 100)
        {
            Cooking.color = Color.green;
        }

        Hunting.text = Player.GetComponent<Hunting>().curLevel.ToString();
        if(Player.GetComponent<Hunting>().curLevel == 100)
        {
            Hunting.color = Color.green;
        }

        Alchemy.text = Player.GetComponent<Alchemy>().curLevel.ToString();
        if(Player.GetComponent<Alchemy>().curLevel == 100)
        {
            Alchemy.color = Color.green;
        }

        Mining.text = Player.GetComponent<Mining>().curLevel.ToString();
        if(Player.GetComponent<Mining>().curLevel == 100)
        {
            Mining.color = Color.green;
        }

        Smithing.text = Player.GetComponent<Smithing>().curLevel.ToString();
        if (Player.GetComponent<Smithing>().curLevel == 100)
        {
            Smithing.color = Color.green;
        }

        Crafting.text = Player.GetComponent<Crafting>().curLevel.ToString();
        if(Player.GetComponent<Crafting>().curLevel == 100)
        {
            Crafting.color = Color.green;
        }
    }
}
