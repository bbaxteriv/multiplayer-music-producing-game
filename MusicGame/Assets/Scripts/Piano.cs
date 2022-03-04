using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public float SemitoneOffset = 0;
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
                    hit.collider.gameObject.GetComponent<Piano>().PlayNote();
                    hit.collider.gameObject.GetComponent<Piano>().ChangeColor();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                GetComponent<SpriteRenderer>().color = OriginalColor;
            }
        }
    }

    void OnMouseDown() // mouse click
    {
        PlayNote();
        ChangeColor();
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = OriginalColor;
    }

    void PlayNote()
    {
        GetComponent<AudioSource>().pitch = Mathf.Pow(2f, SemitoneOffset/12.0f);
        GetComponent<AudioSource>().Play();
    }

    void ChangeColor()
    {
        if (OriginalColor == Color.white) // white key
        {
            GetComponent<SpriteRenderer>().color = new Color(230f/255f, 230f/255f, 230f/255f);
        }
        else // black key
        {
            GetComponent<SpriteRenderer>().color = new Color(60f/255f, 60f/255f, 60f/255f);
        }
    }
}