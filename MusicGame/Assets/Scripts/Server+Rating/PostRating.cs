using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;


public class PostRating : MonoBehaviour
{
    private string postRatingURL = "https://1920.lakeside-cs.org/MultiplayerMusicGame/MusicGame/postrating.php?";
    public List<Star> stars; //idk if this works
    public Button postRatingButton;

    // Start is called before the first frame update
    void Start()
    {
      postRatingButton.onClick.AddListener(() =>
          StartCoroutine(postRating()));
    }


    IEnumerator postRating()
    {
        int rating = 0;
        foreach (Star star in stars)
        {
          if (star.GetComponent<SpriteRenderer>().color == new Color (255,240,0,255))
          {
            rating++;
          }
        }
        Debug.Log(rating);
        // Build url string with parameters
        string post_url = postRatingURL + "rating=" + rating + "&p_id="
                        + "0";
        // Execute request
        UnityWebRequest hs_post = UnityWebRequest.Post(post_url, "");
        yield return hs_post.SendWebRequest();
        // Display error
        if (hs_post.error != null)
            Debug.Log("There was an error in storing the rating: " + hs_post.error);
    }
}
