using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordButton : MonoBehaviour
{
    private AudioRenderer Renderer;
    private int ClickNumber;

    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = Camera.main;
        Renderer = MainCamera.GetComponent<AudioRenderer>();
        Renderer.Rendering = false;
        ClickNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Starts recording first time button is clicked, ends it second time
    public void Record()
    {
        ClickNumber++;

        if (ClickNumber % 2 == 1) // start recording
        {
            Renderer.Rendering = true;
        }
        else // end recording
        {
            EndRecording();
        }
    }

    public void EndRecording()
    {
        Renderer.Save("./Assets/Recordings/file.wav");
        Renderer.Rendering = false;
    }
}