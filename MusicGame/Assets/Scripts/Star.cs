using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
      if (sprite.color == new Color (255,240,0,255))
      {
        sprite.color = new Color (255,255,255,255);
      }
      else
      {
        sprite.color = new Color (255,240,0,255);
      }
    }
}
