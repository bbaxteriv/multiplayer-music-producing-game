using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    bool changeColor = true;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
      if (sprite.color == new Color (255,255,255,255))
      {
        sprite.color = new Color (255,255,255,0);
        changeColor = false;
      }
      else
      {
        sprite.color = new Color (255,255,255,255);
      }
    }
}
