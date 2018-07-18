using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatusCheck : MonoBehaviour
{
    public Text NotificationText;
    private string lastNotification;
    public Uploader upload;

    private string OnlineCheckURL = "https://junsereig.templariusgames.com/GameReqs/GameOnline.php";
    private string StatusCheckURL = "https://junsereig.templariusgames.com/GameReqs/Notification.php";

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(RunChecks());
	}
	
    IEnumerator RunChecks()
    {
        while (true)
        {

            WWW online = new WWW(OnlineCheckURL);
            yield return online;
            if(online.text == "false")
            {
                SaveLoad.Save(upload);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
            }

            //determine if server communication is allowed.
            WWW status = new WWW(StatusCheckURL);
            yield return status;
            

            if (status.text != string.Empty && status.text != lastNotification)
            {
                NotificationText.text = status.text;
                lastNotification = status.text;
            }

            yield return new WaitForSecondsRealtime(60);
        }
    }
}
