using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStats : MonoBehaviour
{
    /// <summary>
    /// null for no style, melee for melee, range for ranged, magic for magic. 
    /// </summary>
    public string Style;
    public bool isPlayer = false;
    public bool overrideBlock = false;

    public GameObject Target;
    private CombatStats TargetStats;
    public BasicAttack basicAttack;
    public EnemyAI ai;

    public GameObject enemyScreen;
    public GameObject objectScreen;

    public GameObject meleeRange;
    public GameObject magicRange;
    public GameObject bowRange;

    /// <summary>
    /// Is blocking mult. 1 for not blocking, 2 for is blocking. Increase further for damage reduction.
    /// </summary>
    public int Block = 1;

    [Tooltip("Unless otherwise stated, 45 if resistant, 55 if neutral, 65 if weak, 90 under special effects")]
    public int Affinity;
    public int ArmourRating;
    public int DivinityBonus;
    public int HealthBonus;
    public float AttackSpeed;
    public int Damage;
    public int Accuracy;
    public float HitChance;
    private float hit;

    private void Start()
    {
        if(Style == string.Empty)
        {
            Style = "melee";
        }
    }

    public void AssignTarget(GameObject target)
    {
        if (target != null)
        {
            Target = target;
            TargetStats = target.GetComponent<CombatStats>();
            ai = TargetStats.ai;
            CalculateHitChance();
        }
        else if(target == null)
        {
            Target = target;
            TargetStats = null;
            ai = null;
        }
    }

    public void ActivateWeapons()
    {
        if (Style == "melee")
        {
            basicAttack.canAttack = true;
            meleeRange.SetActive(true);
        }
        else if(Style == "range")
        {
            basicAttack.canAttack = true;
            bowRange.SetActive(true);
        }
        else if(Style == "magic")
        {
            basicAttack.canAttack = true;
            magicRange.SetActive(true);
        }
        else
        {
            basicAttack.canAttack = false;
        }
    }

    public void DeactivateWeapons()
    {
        meleeRange.SetActive(false);
        magicRange.SetActive(false);
        bowRange.SetActive(false);
        basicAttack.canAttack = false;
    }

	// Use this for initialization
	void Update ()
    {
        if (Input.GetButtonDown("Block") && isPlayer == true && overrideBlock == false)
        {
            Block = 2;
        }
        else if (Input.GetButtonUp("Block") && isPlayer == true && overrideBlock == false)
        {
            Block = 1;
        }
	}

    public void EnemyBasicAttack()
    {
        CalculateHitChance();

        hit = Random.Range(0, 100);

        if(hit < HitChance)
        {
            Target.GetComponent<PlayerHealth>().AdjustHealth((Damage / TargetStats.Block) * -1);
        }
    }

	
    public void BasicAttack()
    {
        if (ai != null)
        {
            if (ai.target != null)
            {
                ai.SetTarget(gameObject);
            }

            hit = Random.Range(0, 100);
            print(hit);

            if (hit < HitChance)
            {
                Target.GetComponent<EnemyHealth>().AdjustHealth((Damage / TargetStats.Block) * -1);
            }
        }
    }

    public void CalculateHitChance()
    {
        if (TargetStats.ArmourRating == 0)
        {
            HitChance = (float)((float)TargetStats.Affinity * ((float)Accuracy / (float)1));
        }
        else
        {
            HitChance = (float)((float)TargetStats.Affinity * ((float)Accuracy / (float)TargetStats.ArmourRating));
        }
    }
}
