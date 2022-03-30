using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float SemitoneOffset = 0;
    private Color OriginalColor;

    // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }


    // Manage touchscreen functionality
    public void Touchscreen()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit) // touchscreen
                {
                    hit.collider.gameObject.GetComponent<Note>().PlayNote();
                    hit.collider.gameObject.GetComponent<Note>().ChangeColor();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                RestoreColor();
            }
        }
    }


    // Adjust pitch and play note
    public void PlayNote()
    {
        GetComponent<AudioSource>().pitch = Mathf.Pow(2f, SemitoneOffset/12.0f);
        GetComponent<AudioSource>().Play();
    }


    // Change color based on original color
    public void ChangeColor()
    {
        // If original color is white change to light grey
        if (OriginalColor == Color.white)
        {
            GetComponent<SpriteRenderer>().color = new Color(230f/255f, 230f/255f, 230f/255f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(60f/255f, 60f/255f, 60f/255f);
        }
    }


    // Restore original color
    public void RestoreColor()
    {
        GetComponent<SpriteRenderer>().color = OriginalColor;
    }


}
