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
        PlayButton.onClick.AddListener(() => Play());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Play()
    {
        Guitar.PlayChord();
    }
}
