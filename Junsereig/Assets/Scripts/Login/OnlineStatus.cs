using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OnlineStatus : MonoBehaviour
{
    public Text loadingText;
    public Image icon;
    public Color loadingColour;
    public Color onlineColour;
    public Color monitoring;
    public Color disrupted;
    public Color offline;
    public Color maintenance;

    private string OnlineCheckURL = "https://junsereig.templariusgames.com/GameReqs/GameOnline.php";
    private string StatusCheckURL = "https://junsereig.templariusgames.com/GameReqs/ServerStatus.php";

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(CheckServerStatus());
	}

    IEnumerator CheckServerStatus()
    {
        while (true)
        {
            icon.color = loadingColour;
            loadingText.text = "Communicating with servers...";
            //determine if server communication is allowed.
            WWW online = new WWW(OnlineCheckURL);
            yield return new WaitForSeconds(1);
            yield return online;

            if (online.text == "true")
            {

                //determine if server communication is allowed.
                WWW status = new WWW(StatusCheckURL);
                yield return status;

                if (status.text == "online")
                {
                    loadingText.text = "Servers online";
                    icon.color = onlineColour;
                }
                else if (status.text == "monitoring")
                {
                    loadingText.text = "Servers are being monitored. Issues may occur during play, but play is not restricted.";
                    icon.color = monitoring;
                }
                else
                {
                    loadingText.text = "An unknown error has occured. Please try again later.";
                    icon.color = offline;
                }
            }
            else if (online.text == "false")
            {
                //determine if server communication is allowed.
                WWW status = new WWW(StatusCheckURL);
                yield return status;

                if (status.text == "disrupted")
                {
                    loadingText.text = "Servers are having issues at this time. Play quality may be degraded";
                    icon.color = disrupted;
                }
                else if(status.text == "maintenance")
                {
                    loadingText.text = "Servers are under maintenance right now. Please try again later.";
                    icon.color = maintenance;
                }
                else if (status.text == "offline")
                {
                    loadingText.text = "Servers are offline at this time. Please check status.templariusgames.com for updates.";
                    icon.color = offline;
                }
                else
                {
                    loadingText.text = "An unknown error has occured. Please try again later.";
                    icon.color = offline;
                }
            }
            else
            {
                loadingText.text = "An unknown error has occured. Please try again later.";
                icon.color = offline;
            }

            yield return new WaitForSecondsRealtime(60);
        }
    }
}
