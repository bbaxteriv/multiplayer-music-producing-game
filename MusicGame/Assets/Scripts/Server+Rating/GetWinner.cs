using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class GetWinner : MonoBehaviour
{
    private string getWinnerURL = "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/getwinner.php?";
    public Button getWinnerButton;
    public Text gameID;

    // Start is called before the first frame update
    void Start()
    {
      getWinnerButton.onClick.AddListener(() => StartCoroutine(getWinner(gameID.text)));
    }


    IEnumerator getWinner(string id)
    {
      // Execute request
      string get_url = getWinnerURL + "g_id=" + Globals.gameID;

      UnityWebRequest hs_get = UnityWebRequest.Get(get_url);
      yield return hs_get.SendWebRequest();
      // Display error
      if (hs_get.error != null)
        Debug.Log("There was an error getting the winner: " + hs_get.error);
      // Get id
      string dataText = hs_get.downloadHandler.text;
      gameID.text = dataText;
    }
}
