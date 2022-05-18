using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoverScript : MonoBehaviour
{
    private int _width = 16;
    private int _height = 9;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
