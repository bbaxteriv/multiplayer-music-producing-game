using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordButton : MonoBehaviour
{
    private AudioRenderer Renderer;
    private int clickNumber;
    public Button RecButton;
    public GameObject TrackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = Camera.main;
        Renderer = MainCamera.GetComponent<AudioRenderer>();
        Renderer.Rendering = false;
        clickNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Starts recording first time button is clicked, ends it second time
    public void Record()
    {
        clickNumber++;

        if (clickNumber % 2 == 1) // start recording
        {
            Renderer.Rendering = true;
            RecButton.GetComponent<Image>().color = new Color(166f/255f, 0, 0);
        }
        else // end recording
        {
            EndRecording();
            SaveToTrack();
            RecButton.GetComponent<Image>().color = new Color(1, 0, 0);
        }
    }

    public void EndRecording()
    {
        Renderer.Save("./Assets/Resources/Recordings/recording_" + clickNumber / 2 + ".wav");
        Renderer.Rendering = false;
    }

    // locate saved file, create new object in tracks scene, set that file as its audio source
    public void SaveToTrack()
    {
        GameObject newTrack = Instantiate(TrackPrefab);
        newTrack.transform.position = new Vector3(-3, clickNumber, 1);
        newTrack.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Recordings/recording_" + clickNumber / 2);
    }
}