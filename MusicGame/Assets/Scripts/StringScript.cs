using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringScript : MonoBehaviour
{
    public float SemitoneOffset = 0;
    private Color OriginalColor;


    // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }


    // When mouse begins hovering over the string play note and change color
    void OnMouseEnter()
    {
        // Only play when shift key is not being pressed
        if (!Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift))
        {
            PlayNote();
            ChangeColor();
        }
    }


    // When mouse stops hovering over the string reset color
    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = OriginalColor;
    }


    // Adjust pitch and play note
    void PlayNote()
    {
        GetComponent<AudioSource>().pitch = Mathf.Pow(2f, SemitoneOffset / 12.0f);
        GetComponent<AudioSource>().Play();
    }


    // Change color slightly
    void ChangeColor()
    {
        if (OriginalColor == Color.white) // white key
        {
            GetComponent<SpriteRenderer>().color = new Color(210f/255f, 210f/255f, 210f/255f);
        }
    }
}
