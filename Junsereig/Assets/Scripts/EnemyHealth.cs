using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Unless specified, set equal to Vitality * 100")]
    public int maxHealth = 100;
    public int curHealth = 100;
    public Image HealthBar;
    public int vitalityXP = 0;
    public int combatXP = 0;
    public int hunterXP = 0;
    public GameObject AI;
    public GameObject Range;
    public int animDelay;
    public GameObject self;
    public EnemyAI enemyai;


    public void AdjustHealth(int adj)
    {
        curHealth += adj;

        HealthBar.fillAmount = (float)((float)curHealth / (float)maxHealth);

        if (curHealth <= 0)
        {
            curHealth = 0;
            print("slain");
            AI.SetActive(false);
            Range.SetActive(false);
            StartCoroutine(Death());
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
    }

    public IEnumerator Death()
    {
        //play death animation
        //calculate drops (not implemented yet)
        enemyai.target = null;
        enemyai.PlayerTarget = null;

        yield return new WaitForSeconds(animDelay);

        if(GameObject.FindGameObjectWithTag("EnemyScreen") != null)
        {
            GameObject.FindGameObjectWithTag("EnemyScreen").GetComponent<EnemyScreen>().Deselect();
        }
        GameObject target = gameObject.GetComponent<CombatStats>().Target;

        target.GetComponent<Vitality>().AddXP(vitalityXP);

        if(target.GetComponent<CombatStats>().Style == "melee")
        {
            target.GetComponent<Blademaster>().AddXP(combatXP);
        }
        else if(target.GetComponent<CombatStats>().Style == "range")
        {
            target.GetComponent<Bowmaster>().AddXP(combatXP);
        }
        else if(target.GetComponent<CombatStats>().Style == "magic")
        {
            target.GetComponent<Runemaster>().AddXP(combatXP);
        }

        target.GetComponent<Hunting>().AddXP(hunterXP);

        Destroy(self);
        //drop items (not implemented)
    }

}
