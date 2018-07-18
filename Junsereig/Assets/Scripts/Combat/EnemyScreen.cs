using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScreen : MonoBehaviour
{
    public GameObject Player;
    public GameObject ObjectScreen;
    public GameObject Target;
    public EnemyHealth TargetHealth;
    public Text Name;
    public Text Style;
    public Text Desc;
    public Text CombatRating;
    public Outline outline;
    public Image HealthBar;
    public Color green;
    public Color yellow;
    public Color red;
    public Color black;

    public void SelectTarget(GameObject target, string TargetName, string TargetStyle, string TargetDesc, int TargetRating, int Modifier)
    {
        Target = target;
        Player.GetComponent<CombatStats>().AssignTarget(target);
        Name.text = TargetName;
        Style.text = TargetStyle;
        Desc.text = TargetDesc;
        CombatRating.text = TargetRating.ToString();
        TargetHealth = Target.GetComponent<EnemyHealth>();
        if(Modifier != 0)
        {
            CombatRating.text += " + " + Modifier;
        }

        //modify rating and healthbar to reflect difficulty
        if ((OverallSkill.PlayerCombatRating - (TargetRating + Modifier) < 0))
        {
            if (OverallSkill.PlayerCombatRating == 140)
            {
                if ((TargetRating + Modifier) <= OverallSkill.PlayerCombatRating)
                {
                    HealthBar.color = green;
                    CombatRating.color = green;
                    outline.enabled = false;
                }
                else
                {
                    HealthBar.color = yellow;
                    CombatRating.color = yellow;
                    outline.enabled = false;
                }
            }

            else if ((OverallSkill.PlayerCombatRating - (TargetRating + Modifier)) < -80)
            {
                HealthBar.color = black;
                CombatRating.color = black;
                outline.enabled = true;
            }
            else if ((OverallSkill.PlayerCombatRating - (TargetRating + Modifier) < -6))
            {
                HealthBar.color = red;
                CombatRating.color = red;
                outline.enabled = false;
            }
            else
            {
                HealthBar.color = yellow;
                CombatRating.color = yellow;
                outline.enabled = false;
            }
        }
        else if ((OverallSkill.PlayerCombatRating - (TargetRating - Modifier) > 0))
        {
            if ((OverallSkill.PlayerCombatRating - (TargetRating + Modifier)) < 5)
            {
                HealthBar.color = yellow;
                CombatRating.color = yellow;
                outline.enabled = false;
            }
            else
            {
                HealthBar.color = green;
                CombatRating.color = green;
                outline.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = (float)((float)TargetHealth.curHealth / (float)TargetHealth.maxHealth);

        if(ObjectScreen.activeSelf == true)
        {
            Target.GetComponentInChildren<EnemyObject>().HealthBar.SetActive(false);
            Target = null;
            gameObject.SetActive(false);
            Player.GetComponent<CombatStats>().AssignTarget(null);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Target.GetComponentInChildren<EnemyObject>().HealthBar.SetActive(false);
            Target = null;
            gameObject.SetActive(false);
            Player.GetComponent<CombatStats>().AssignTarget(null);
        }
    }

    public void Deselect()
    {
        Target.GetComponentInChildren<EnemyObject>().HealthBar.SetActive(false);
        Target = null;
        gameObject.SetActive(false);
    }
}
