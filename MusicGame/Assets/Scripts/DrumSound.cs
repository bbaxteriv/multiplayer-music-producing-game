using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumSound : MonoBehaviour
{
    // Check if touchscreen is being used every frame
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
        gameObject.GetComponent<Drum>().PlayNote();
    }

    /*void OnMouseUp()
    {
        RestoreColor();
    }*/

    /*void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(210f/255f, 210f/255f, 210f/255f);
    }

    // Restore color when mouse stops clicking
    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = OriginalColor;
    }*/
}