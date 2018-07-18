using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using UnityEngine.UI;

public class DataLoad : MonoBehaviour
{
    public Text LoadingProgress;
    public Uploader upload;
    public GameObject player;
    public GameObject console;
    public GameObject UImode;

	// Use this for initialization
	void Start ()
    {
        if(GameObject.Find("DevConsole(Clone)") == null)
        {
            Instantiate(console);
        }
        if(GameObject.Find("UI Mode Manager(Clone)") == null)
        {
            Instantiate(UImode);
        }

        StartCoroutine(LoadData());
	}

    IEnumerator LoadData()
    {
        LoadingProgress.text = string.Empty;
        yield return new WaitForSeconds(1);

        LoadingProgress.text = "Determining save location";
        yield return new WaitForSeconds(1);

        WWW www = new WWW("http://junsereig.templariusgames.com/saves/" + Uploader.PlayerID + ".sav");
        yield return www;

        if (www.text.Contains("404"))
        {
            //loads with no data (debug)
            SceneManager.LoadScene("demo");
            Instantiate(player);
        }
        else
        {

            if (File.Exists(Application.persistentDataPath + "/" + Uploader.PlayerID + ".sav"))
            {
                LoadingProgress.text = "Loading local files";
                SceneManager.LoadScene(SceneTransition.currentScene);
                Instantiate(player);
            }
            else
            {
                LoadingProgress.text = "Downloading from server (may take a few moments)";
                upload.DownloadFile();
                yield return new WaitForSeconds(2);
                SceneManager.LoadScene(SceneTransition.currentScene);
                Instantiate(player);
            }
        }
    }
}
