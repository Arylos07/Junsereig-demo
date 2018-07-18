using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public static int Damage = 0;
    public static int Accuracy = 0;
    public static int Armour = 0;
    public static string Style;
    public Text DamageText;
    public Text AccuracyText;
    public Text ArmourText;
    public int PositiveAffinity;
    public int NeutralAffinity;
    public int NegativeAffinity;
    public GameObject SelectedEnemy;
    public List<GameObject> Enemies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
