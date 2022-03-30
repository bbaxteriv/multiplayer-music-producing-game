using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour
{
    private Color OriginalColor;

    // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit) // touchscreen
                {
                    hit.collider.gameObject.GetComponent<Drum>().PlayNote();
                    //hit.collider.gameObject.GetComponent<Drum>().ChangeColor();
                }
            }

            /*if (touch.phase == TouchPhase.Ended)
            {
                RestoreColor();
            }*/
        }
    }

    void OnMouseDown() // mouse click
    {
        PlayNote();
    }

    /*void OnMouseUp()
    {
        RestoreColor();
    }*/

    void PlayNote()
    {
        GetComponent<AudioSource>().Play();
    }

    /*void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(210f/255f, 210f/255f, 210f/255f);
    }

    void RestoreColor()
    {
        GetComponent<SpriteRenderer>().color = OriginalColor;
    }*/
}
