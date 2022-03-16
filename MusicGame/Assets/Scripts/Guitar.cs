using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guitar : MonoBehaviour
{
    public Dropdown Dropdown;
    public List<AudioSource> Chords;
    private Color OriginalColor;

    // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayChord()
    {
        if (Dropdown.value == 0)
        {
            return;
        }
        AudioSource Chord = Chords[Dropdown.value - 1];
        Chord.Play();
    }
}
