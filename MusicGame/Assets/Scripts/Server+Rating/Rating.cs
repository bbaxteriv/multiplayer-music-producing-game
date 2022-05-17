/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    public GameObject[] stars;
    SpriteRenderer [] star;
    string name;
    int starNumber;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
      for(var i = 0; i <stars.Count; i++)
      {
        star[i] = stars[i].GetComponent<SpriteRenderer>();
      }
    }

    // Update is called once per frame
    void Update()
    {

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
                    name = hit.collider.name;
                    int.TryParse(name, out starNumber);
                    for(var i = starNumber; i< 0; i--)
                    {
                      sprite = star[i];
                      sprite.color = new Color (255,240,0,255);
                    }
                }
            }
        }
    }
}
*/
