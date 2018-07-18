using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    public Image HealthBar;
    public Image OverheadBar;
    public int CombatLevel = 0;
    public CombatStats combatStats;

    public void AdjustHealth(int adj)
    {
        curHealth += adj;

        HealthBar.fillAmount = (float)((float)curHealth / (float)maxHealth);
        OverheadBar.fillAmount = (float)((float)curHealth / (float)maxHealth);

        if (curHealth < 0)
        {
            curHealth = 0;
        }

        if(curHealth <= 0)
        {
            gameObject.GetComponent<CombatStats>().AssignTarget(null);
            combatStats.enemyScreen.GetComponent<EnemyScreen>().Deselect();
            combatStats.objectScreen.SetActive(false);
            SceneManager.LoadScene("Death");
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(maxHealth < 1)
        {
            maxHealth = 1;
        }
    }

}
