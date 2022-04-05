using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringScript : Note
{
	private bool playable = true;
	private SpriteRenderer sprite;
	
	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}
    void Update()
    {
        // Only play note when shift keys is pressed
        if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && playable == true)
        {
            base.Touchscreen();
        }
    }


    // When mouse begins hovering over the string play note and change color
    void OnMouseEnter()
    {
        // Only play when shift key is being pressed
        if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && playable == true)
        {
            base.PlayNote();
            base.ChangeColor();
        }
    }

	void OnMouseDown()
	{
		if(playable == true)
		{
			playable = false;
			sprite.color = new Color(1,0,0,1);
		}
		else if(playable == false)
		{
			playable = true;
			sprite.color = new Color(1,0,0,1);
		}
	}

    // When mouse stops hovering restore color
    void OnMouseExit()
    {
		if(playable == true)
		{
        	base.RestoreColor();
		}
    }
}
