using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Login : MonoBehaviour {

    public string username;
    public string password;

    string OnlineCheckURL = "https://www.games.templariusgames.com/Junsereig/GameReqs/GameOnline.php";
    string LoginURL = "https://www.games.templariusgames.com/Junsereig/GameReqs/Login.php";

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoginDB(username, password));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(URLTest());
        }
    }

    IEnumerator URLTest()
    {
        string post_url = "https://www.games.templariusgames.com/Junsereig/GameReqs/Data.php"; // my url to php parser with parameters (?par1=meh) etc

        WWW post = new WWW(post_url);
        yield return post; // Wait until the download is done
        if (post.error != null)
        {
            Debug.LogError(post.error);
        }
        else
        {
            print("success");
            //success
            //but never gets here on Unity 2017
        }
    }

    IEnumerator LoginDB(string user, string pass)
    {
        //determine if server communication is allowed.
        WWW online = new WWW(OnlineCheckURL);
        yield return online;

        if (online.text == "false")
        {
            Debug.Log("Server communication offline; cannot log in.");
        }

        //if server communication is allowed, authenticate user.
        else if (online.text == "true")
        {
            //send usernamePost and passwordPost to php for authentication
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", user);
            form.AddField("passwordPost", pass);

            UnityWebRequest www = UnityWebRequest.Post(LoginURL, form);

            //Set DownloadHandler instance
            DownloadHandlerBuffer dH = new DownloadHandlerBuffer();
            www.downloadHandler = dH;
            www.chunkedTransfer = false;

            //wait for response
            yield return www;

            if (www.error != null)
            {
                if (www.isNetworkError)
                {
                    Debug.Log("Network error: " + www.error);
                }
                else if (www.isHttpError)
                {
                    Debug.Log("HTTP error: " + www.error);
                    print(www.responseCode);
                }
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
