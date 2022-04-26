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
            "http://localhost/addtrack.php?";
    public string displayURL =
             "http://localhost/display.php";
    public Text wavTextInput;
    public Text wavResultText;

    public void GetScoreBtn()
    {
        wavResultText.text = "Wav: ";
        StartCoroutine(GetScores());
    }
    
    public void SendScoreBtn()
    {
        StartCoroutine(PostScores(wavTextInput.text));
        wavTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
    }
    
    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get(displayURL);
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the display: "
                    + hs_get.error);
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
        string post_url = addTrackURL + "Username=testtt" + "&Wav="
               + wav + "&Rating=101" + "&ID=777";
        Debug.Log(post_url);
        UnityWebRequest hs_post = UnityWebRequest.Post(post_url, "");
        yield return hs_post.SendWebRequest();
        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: "
                    + hs_post.error);
    }
}
