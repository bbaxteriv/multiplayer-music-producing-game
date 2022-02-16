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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        speed = 2f;
        int number;
        if (int.TryParse(speedText.text.ToString(), out number))
        {
            speed = number;
        }
        if (speed > 20f)
        {
            speed = 20f;
        }
        pos = transform.position;
        rb.velocity = new Vector2(speed, 0f);
        if (pos[0] > 17f)
        {
            transform.position = new Vector3(-1f, 3.99f, 0f);
        }
    }
}
