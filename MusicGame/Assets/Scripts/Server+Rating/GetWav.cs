using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWav : MonoBehaviour
{
	public void clickButton()
	{
      //string url = "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/downloadform.php?";
      //StartCoroutine(fillForm(url));
	  Application.OpenURL("https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/downloadform.php");
    }

    IEnumerator fillForm(string url)
    {
      WWWForm form = new WWWForm();
      form.AddField("gameid", "79");
      WWW www = new WWW(url, form);
      yield return www;
    }
}
