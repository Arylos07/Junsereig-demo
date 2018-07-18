using UnityEngine;
using DevConsole;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [Command(help: "Force quits the game. Useful for crashes or fatal bugs.")]
    static void qqq()
    {
        Application.Quit();
    }

    [Command(help: "Opens the Templarius Studios contact page.")]
    static void Support()
    {
        Console.Log("The Templarius contact page is opening.");
        Application.OpenURL("https://templariusgames.com/support/");
    }

    [Command(help: "Manually gives XP to a skill.")]
    static void GiveXP(string skill, int value)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (skill == "Vitality")
        {
            player.GetComponent<Vitality>().AddXP(value);
        }
        else if (skill == "Divinity")
        {
            player.GetComponent<Divinity>().AddXP(value);
        }
        else if (skill == "Blademaster")
        {
            player.GetComponent<Blademaster>().AddXP(value);
        }
        else if (skill == "Bowmaster")
        {
            player.GetComponent<Bowmaster>().AddXP(value);
        }
        else if (skill == "Runemaster")
        {
            player.GetComponent<Runemaster>().AddXP(value);
        }
        else if (skill == "Defence")
        {
            player.GetComponent<Defence>().AddXP(value);
        }
        else if (skill == "Agility")
        {
            player.GetComponent<Agility>().AddXP(value);
        }
        else if (skill == "Cooking")
        {
            player.GetComponent<Cooking>().AddXP(value);
        }
        else if (skill == "Hunting")
        {
            player.GetComponent<Hunting>().AddXP(value);
        }
        else if (skill == "Alchemy")
        {
            player.GetComponent<Alchemy>().AddXP(value);
        }
        else if (skill == "Mining")
        {
            player.GetComponent<Mining>().AddXP(value);
        }
        else if (skill == "Smithing")
        {
            player.GetComponent<Smithing>().AddXP(value);
        }
        else if (skill == "Crafting")
        {
            player.GetComponent<Crafting>().AddXP(value);
        }
        else
        {
            Console.LogError("Input " + skill + " is not valid");
        }
    }

    [Command(help: "Generates a random build for the player")]
    static void RandomBuild()
    {
        Console.LogInfo("Creating Random build...");
        GiveXP("Vitality", Random.Range(1, 15000000));
        GiveXP("Divinity", Random.Range(1, 15000000));
        GiveXP("Blademaster", Random.Range(1, 15000000));
        GiveXP("Bowmaster", Random.Range(1, 15000000));
        GiveXP("Runemaster", Random.Range(1, 15000000));
        GiveXP("Defence", Random.Range(1, 15000000));
        GiveXP("Agility", Random.Range(1, 15000000));
        GiveXP("Cooking", Random.Range(1, 15000000));
        GiveXP("Hunting", Random.Range(1, 15000000));
        GiveXP("Alchemy", Random.Range(1, 15000000));
        GiveXP("Mining", Random.Range(1, 15000000));
        GiveXP("Smithing", Random.Range(1, 15000000));
        GiveXP("Crafting", Random.Range(1, 15000000));
        Console.Log("Build generated", Color.green);
    }

    [Command(help: "Set player to max skills")]
    static void MaxPlayer()
    {
        Console.LogInfo("Setting player to max...");
        GiveXP("Vitality", 15000000);
        GiveXP("Divinity", 15000000);
        GiveXP("Blademaster", 15000000);
        GiveXP("Bowmaster", 15000000);
        GiveXP("Runemaster", 15000000);
        GiveXP("Defence", 15000000);
        GiveXP("Agility", 15000000);
        GiveXP("Cooking", 15000000);
        GiveXP("Hunting", 15000000);
        GiveXP("Alchemy", 15000000);
        GiveXP("Mining", 15000000);
        GiveXP("Smithing", 15000000);
        GiveXP("Crafting", 15000000);
        Console.Log("Player maxed", Color.green);
    }
}