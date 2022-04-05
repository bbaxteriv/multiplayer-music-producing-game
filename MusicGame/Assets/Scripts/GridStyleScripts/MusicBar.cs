using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBar : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 pos;
    public Text speedText;
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        speed = 2f;
        // Get input speed
        int number;
        if (int.TryParse(speedText.text.ToString(), out number))
        {
            speed = number;
        }
        // Set max speed
        if (speed > 20f)
        {
            speed = 20f;
        }
        
        pos = transform.position;
        rb.velocity = new Vector2(speed, 0f);
        // Go back to beginning of grid after reaching the end
        if (pos[0] > 13f)
        {
            transform.position = new Vector3(-1f, 3.99f, 0f);
        }
    }
}
