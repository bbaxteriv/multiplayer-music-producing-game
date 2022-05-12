using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class serverControl : MonoBehaviour
{
    public string addTrackURL =
            "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/addtrack.php?";
    public string displayURL =
             "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/display.php";
    public Text usernameTextInput;
    public Text wavResultText;

    public void GetScoreBtn()
    {
        wavResultText.text = "Wav: ";
        StartCoroutine(GetScores());
    }
    
    public void SendScoreBtn()
    {
        StartCoroutine(PostScores(usernameTextInput.text));
        usernameTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
    }
    
    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get(displayURL);
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the display: " + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            string[] dataArray = dataText.Split('_');

            Debug.Log(wavResultText.text);

            wavResultText.text = wavResultText.text + dataArray[1];

            Debug.Log(wavResultText.text);
        }
    }
    
    IEnumerator PostScores(string wav)
    {
        string post_url = addTrackURL + "Username=testtt" + "&Wav=" + wav + "&Rating=10000" + "&ID=502" + "&gameid=102";
        Debug.Log(post_url);
        UnityWebRequest hs_post = UnityWebRequest.Post(post_url, "");
        yield return hs_post.SendWebRequest();
        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: " + hs_post.error);
    }
}
