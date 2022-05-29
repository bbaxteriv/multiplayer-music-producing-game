using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class JoinGame : MonoBehaviour
{
    private string joinGameURL = "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/joingame.php?";
    private string getLastPIDURL = "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/getlastplayerid.php";
    public Button joinGameButton;
    public Text gameID;
    public Text gameName;
    public Text username;

    // Start is called before the first frame update
    void Start()
    {
      joinGameButton.onClick.AddListener(() =>
          StartCoroutine(joinGame(gameName.text, gameID.text, username.text)));
    }


    IEnumerator joinGame(string name, string gameID, string username)
    {
        Globals.gameID = gameID;
        Globals.username = username;
        // Build url string with parameters
        string post_url = joinGameURL + "gamename=" + name + "&id="
                        + gameID + "&username=" + username;
        // Execute request
        UnityWebRequest hs_post = UnityWebRequest.Post(post_url, "");
        yield return hs_post.SendWebRequest();
        // Display error
        if (hs_post.error != null)
            Debug.Log("There was an error in joining the game: " + hs_post.error);
        StartCoroutine(getPlayerID(gameID));
    }

    IEnumerator getPlayerID(string gameID)
    {
      // Execute request
      UnityWebRequest hs_get = UnityWebRequest.Get(getLastPIDURL);
      yield return hs_get.SendWebRequest();
      // Display error
      if (hs_get.error != null)
        Debug.Log("There was an error getting the player id: " + hs_get.error);
      // Get id
      string dataText = hs_get.downloadHandler.text;
      Globals.playerID = dataText;
    }
}
