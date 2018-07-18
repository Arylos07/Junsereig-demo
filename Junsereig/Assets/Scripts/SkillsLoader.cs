using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsLoader : MonoBehaviour
{
    public GameObject Player;
    public Agility agility;
    public Alchemy alchemy;
    public Blademaster blademaster;
    public Bowmaster bowmaster;
    public Runemaster runemaster;
    public Cooking cooking;
    public Crafting crafting;
    public Defence defence;
    public Divinity divinity;
    public Hunting hunting;
    public Mining mining;
    public Smithing smithing;
    public Vitality vitality;

    public Uploader upload;

    public static bool SaveLoaded = false;

    public static int Agility;
    public static int Alchemy;
    public static int Blademaster;
    public static int Bowmaster;
    public static int Runemaster;
    public static int Cooking;
    public static int Crafting;
    public static int Defence;
    public static int Divinity;
    public static int Hunting;
    public static int Mining;
    public static int Smithing;
    public static int Vitality;

	// Use this for initialization
	void Start ()
    {
        SaveLoad.Load();
        //Debug loading
        LoadData();

		//if(SaveLoaded == true)
  //      {
  //          agility.SetXP(Agility);
  //          alchemy.SetXP(Alchemy);
  //          blademaster.SetXP(Blademaster);
  //          bowmaster.SetXP(Bowmaster);
  //          runemaster.SetXP(Runemaster);
  //          cooking.SetXP(Cooking);
  //          crafting.SetXP(Crafting);
  //          defence.SetXP(Defence);
  //          divinity.SetXP(Divinity);
  //          hunting.SetXP(Hunting);
  //          mining.SetXP(Mining);
  //          smithing.SetXP(Smithing);
  //          vitality.SetXP(Vitality);
  //      }
	}

    public static void ResetValues()
    {
        Agility = 0;
        Alchemy = 0;
        Blademaster = 0;
        Bowmaster = 0;
        Runemaster = 0;
        Cooking = 0;
        Crafting = 0;
        Defence = 0;
        Divinity = 0;
        Hunting = 0;
        Mining = 0;
        Smithing = 0;
        Vitality = 0;
    }

    public void Logout()
    {
        Agility = agility.curXP;
        Alchemy = alchemy.curXP;
        Blademaster = blademaster.curXP;
        Bowmaster = bowmaster.curXP;
        Runemaster = runemaster.curXP;
        Cooking = cooking.curXP;
        Crafting = crafting.curXP;
        Defence = defence.curXP;
        Divinity = divinity.curXP;
        Hunting = hunting.curXP;
        Mining = mining.curXP;
        Smithing = smithing.curXP;
        Vitality = vitality.curXP;
        upload.Logout();
    }

    public void LoadData()
    {
        Player.GetComponent<PlayerPosition>().LoadPosition();
        agility.SetXP(Agility);
        alchemy.SetXP(Alchemy);
        blademaster.SetXP(Blademaster);
        bowmaster.SetXP(Bowmaster);
        runemaster.SetXP(Runemaster);
        cooking.SetXP(Cooking);
        crafting.SetXP(Crafting);
        defence.SetXP(Defence);
        divinity.SetXP(Divinity);
        hunting.SetXP(Hunting);
        mining.SetXP(Mining);
        smithing.SetXP(Smithing);
        vitality.SetXP(Vitality);
    }
}
