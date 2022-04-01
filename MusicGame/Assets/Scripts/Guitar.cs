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


    // Play chord selected from the dropdown menu
    public void PlayChord()
    {
        // Skip first value because it is just "select chord"
        if (Dropdown.value == 0)
        {
            return;
        }
        AudioSource Chord = Chords[Dropdown.value - 1];
        Chord.Play();
    }
}
