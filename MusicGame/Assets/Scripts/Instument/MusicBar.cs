using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




//BY DEFAULT: SPEED = 2; SONG LENGTH = 14



public class MusicBar : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 pos;
    public Text speedText;
    public float speed;
    public Text lengthText;
    public float length;

    private float snapBackPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        speed = 2f;

        length = 14f;

        snapBackPosition = length - 1f;

        // Get input speed
        int number1;
        if (int.TryParse(speedText.text.ToString(), out number1))
        {
            speed = number1;
        }
        // Get input length
        
        int number2;
        if (int.TryParse(lengthText.text.ToString(), out number2))
        {
            length = number2;
        }

        snapBackPosition = length - 1f;

        // Set max speed
        if (speed > 20f)
        {
            speed = 20f;
        }

        pos = transform.position;
        rb.velocity = new Vector2(speed, 0f);
        // Go back to beginning of grid after reaching the end
        if (pos[0] > snapBackPosition)
        {
            transform.position = new Vector3(-1f, 3.99f, 0f);
        }
    }
}
