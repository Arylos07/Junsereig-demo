using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public CombatStats combatStats;
    public GameObject EnemyPanel;
    public GameObject HealthBar;
    public string Name;
    public string Style;
    [TextArea]
    public string Desc;
    public int CombatRating;
    public int Modifier;
    public int Blademaster;
    public int Bowmaster;
    public int Runemaster;
    public int Defence;
    public int Vitality;
    public int Divinity;
    public int Hunting;

    private void OnMouseDown()
    {
        if (AdjustCameraFocus.CameraFocus == false)
        {
            CombatRating = (int)(((1.3) * Mathf.Max((Blademaster * 2), (Runemaster * 2), (Bowmaster * 2)) + Defence + Vitality + (Divinity * 0.5) + (Hunting * 0.5)) / 4);

            if (EnemyPanel != null)
            {
                EnemyPanel.GetComponent<EnemyScreen>().SelectTarget(gameObject, Name, Style, Desc, CombatRating, Modifier);
            }
            else if(EnemyPanel == null)
            {
                EnemyPanel = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatStats>().enemyScreen;
                EnemyPanel.GetComponent<EnemyScreen>().SelectTarget(gameObject, Name, Style, Desc, CombatRating, Modifier);
            }

            if (HealthBar != null)
            {
                HealthBar.SetActive(true);
            }
            EnemyPanel.SetActive(true);
        }
    }
}
