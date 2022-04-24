using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System;

public class highScore : MonoBehaviour
{

    public int highscore;
    public Text HighscoreTxt;

    //Vul hier onder het script aan

    public void PostScore()
    {
        StartCoroutine(GetRequest("https://87602.ict-lab.nl/PlatformerUnityLeaderboard/displayScore.php"));

        StartCoroutine(Upload());
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            //display highscores from database
            HighscoreTxt.text = "Highscores:\n" + webRequest.downloadHandler.text;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }


    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "duran");
        form.AddField("score", highscore);

        using (UnityWebRequest www = UnityWebRequest.Post("https://87602.ict-lab.nl/PlatformerUnityLeaderboard/addscore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}