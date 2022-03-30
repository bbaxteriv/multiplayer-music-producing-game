using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringScript : Note
{
    void Update()
    {
        // Only play note when shift keys not pressed
        if (!Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift))
        {
            base.Touchscreen();
        }
    }


    // When mouse begins hovering over the string play note and change color
    void OnMouseEnter()
    {
        // Only play when shift key is not being pressed
        if (!Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift))
        {
            base.PlayNote();
            base.ChangeColor();
        }
    }


    // When mouse stops hovering restore color
    void OnMouseExit()
    {
        base.RestoreColor();
    }
}
