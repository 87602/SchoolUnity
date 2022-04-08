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

    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "score");

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