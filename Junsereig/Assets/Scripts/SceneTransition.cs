using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static string currentScene;
    public CombatStats combatStats;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void ChangeScene(string name, Vector3 position)
    {
        gameObject.GetComponent<CombatStats>().AssignTarget(null);
        combatStats.enemyScreen.SetActive(false);
        combatStats.objectScreen.SetActive(false);
        SceneManager.LoadScene(name);
        currentScene = name;
        transform.position = position;
    }
}