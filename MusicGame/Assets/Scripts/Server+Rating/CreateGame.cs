// TODO: TRANSFER DATABASE TO 1920 SERVER???
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class CreateGame : MonoBehaviour
{
    private string createGameURL = "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/creategame.php?";
    private string joinGameURL = "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/joingame.php?";
    public Button createGameButton;
    public Text gameID;
    public Text gameName;

    // Start is called before the first frame update
    void Start()
    {
      createGameButton.onClick.AddListener(() => StartCoroutine(createGame(gameName.text)));
    }


    IEnumerator createGame(string name)
    {
        // Build url string with parameters
        string get_url = createGameURL + "gamename=" + name + "&username=TESTUSER";
        Debug.Log(get_url);

        // Execute request
        UnityWebRequest hs_get = UnityWebRequest.Get(get_url);
        yield return hs_get.SendWebRequest();
        string dataText = hs_get.downloadHandler.text;
        Debug.Log(dataText);
        // Display error if any
        if (hs_get.error != null)
            Debug.Log("There was an error in creating the game: " + hs_get.error);
        gameID.text = dataText;
/*
        // Build url string with parameters
        string post_url = joinGameURL + "gamename=" + name + "&id="
                        + gameID.text + "&username=TESTUSER";
        Debug.Log(post_url);
        // Execute request
        UnityWebRequest hs_post = UnityWebRequest.Post(post_url, "");
        yield return hs_post.SendWebRequest();
        // Display error
        if (hs_post.error != null)
          Debug.Log("There was an error in joining the game: " + hs_post.error);*/
    }
}
