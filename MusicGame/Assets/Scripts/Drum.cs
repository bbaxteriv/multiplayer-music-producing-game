using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : Note
{
    // Check if touchscreen is being used every frame
    void Update()
    {
        base.Touchscreen();
    }


    // Play note and change color when clicked
    void OnMouseDown()
    {
		    base.PlayNote();
        base.ChangeColor();
    }


    // Restore color when mouse stops clicking
    void OnMouseUp()
    {
        base.RestoreColor();
    }
}
