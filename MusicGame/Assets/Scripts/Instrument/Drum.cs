using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : Note
{
    // Check if touchscreen is being used every frame
    void Update()
    {
        Touchscreen();
    }

    // Play note and change color when clicked
    void OnMouseDown()
    {
		    base.PlayNote();
    }

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
                }
            }

        }
    }

}
