using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayChord : MonoBehaviour
{
    public Button PlayButton;
    public Guitar Guitar;
    // Start is called before the first frame update
    void Start()
    {
        // When play button is clicked, play note
        PlayButton.onClick.AddListener(() => Play());
    }


    // Get guitar to play chord
    void Play()
    {
        Guitar.PlayChord();
    }
}
