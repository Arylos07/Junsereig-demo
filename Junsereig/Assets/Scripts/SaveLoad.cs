using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DevConsole;
using UnityEngine.SceneManagement;
using System.Net;

public class SaveLoad : MonoBehaviour
{
    //On method call SaveLoad.Save()
    public static void Save(Uploader uploader)
    {
        //Load binary coding and create a file to write to.
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/" + Uploader.PlayerID + ".sav");

        //Create a copy of the SaveManager to get variables to save.
        SaveManager saver = new SaveManager();
        saver.sceneName = SceneTransition.currentScene;
        saver.PassiveMode = JunsereigCamera.PassiveMode;
        saver.playerPositionX = PlayerPosition.playerPosition.x;
        saver.playerPositionY = PlayerPosition.playerPosition.y;
        saver.playerPositionZ = PlayerPosition.playerPosition.z;
        saver.Agility = SkillsLoader.Agility;
        saver.Alchemy = SkillsLoader.Alchemy;
        saver.Blademaster = SkillsLoader.Blademaster;
        saver.Bowmaster = SkillsLoader.Bowmaster;
        saver.Runemaster = SkillsLoader.Runemaster;
        saver.Cooking = SkillsLoader.Cooking;
        saver.Crafting = SkillsLoader.Crafting;
        saver.Defence = SkillsLoader.Defence;
        saver.Divinity = SkillsLoader.Divinity;
        saver.Hunting = SkillsLoader.Hunting;
        saver.Mining = SkillsLoader.Mining;
        saver.Smithing = SkillsLoader.Smithing;
        saver.Vitality = SkillsLoader.Vitality;
        //Add other variables if needed...

        Debug.Log("Save Successful");

        //Encrypt information
        binary.Serialize(fStream, saver);
        //Close file.
        fStream.Close();
        uploader.UploadFile();
    }

    //On method call SaveLoad.Load()
    public static void Load()
    {
        //Only load if there is an existing file.
        if (File.Exists(Application.persistentDataPath + "/" + Uploader.PlayerID + ".sav"))
        {

            //Load binary formatter and open the file. Decrypt the file and close it.
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/" + Uploader.PlayerID + ".sav", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();

            //Take decrypted variables and add them to the GameController so rules can be adjusted accordingly.
            SceneTransition.currentScene = saver.sceneName;
            JunsereigCamera.PassiveMode = saver.PassiveMode;
            PlayerPosition.playerPosition.x = saver.playerPositionX;
            PlayerPosition.playerPosition.y = saver.playerPositionY;
            PlayerPosition.playerPosition.z = saver.playerPositionZ;
            SkillsLoader.Agility = saver.Agility;
            SkillsLoader.Alchemy = saver.Alchemy;
            SkillsLoader.Blademaster = saver.Blademaster;
            SkillsLoader.Bowmaster = saver.Bowmaster;
            SkillsLoader.Runemaster = saver.Runemaster;
            SkillsLoader.Cooking = saver.Cooking;
            SkillsLoader.Crafting = saver.Crafting;
            SkillsLoader.Defence = saver.Defence;
            SkillsLoader.Divinity = saver.Divinity;
            SkillsLoader.Hunting = saver.Hunting;
            SkillsLoader.Mining = saver.Mining;
            SkillsLoader.Smithing = saver.Smithing;
            SkillsLoader.Vitality = saver.Vitality;
            SkillsLoader.SaveLoaded = true;
            //Add other variables if needed...

        }
    }

    public static void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/" + Uploader.PlayerID + ".sav"))
        {
            File.Delete(Application.persistentDataPath + "/" + Uploader.PlayerID + ".sav");
            DevConsole.Console.Log("Delete Successful!", Color.red);
            //if (SceneManager.GetActiveScene().name != "Loading")
            //{
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //}
        }
    }

}

//Can be serialized
[Serializable]

//Object that records configuration information
class ConfigManager
{
    //public string VersionNumber;
    //public bool EULA_Accepted;
    //public bool FirstLoad;
    //public float MusicVolume;
    //public bool enableMusic;
    //public float SFXVolume;
    //Add other variaables if needed...
}

//Can be serialized
[Serializable]

//Object that records all information to be saved.
class SaveManager
{
    public string sceneName;
    public bool PassiveMode;
    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    public int Agility;
    public int Alchemy;
    public int Blademaster;
    public int Bowmaster;
    public int Runemaster;
    public int Cooking;
    public int Crafting;
    public int Defence;
    public int Divinity;
    public int Hunting;
    public int Mining;
    public int Smithing;
    public int Vitality;
    //Add other variaables if needed...
}