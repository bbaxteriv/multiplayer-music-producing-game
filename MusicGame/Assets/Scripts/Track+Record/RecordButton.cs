using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using UnityEditor;

public class RecordButton : MonoBehaviour
{
    private AudioRenderer Renderer;
    public Button RecButton;
    public GameObject TrackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = Camera.main;
        Renderer = MainCamera.GetComponent<AudioRenderer>();
        Renderer.Rendering = false;

        if (!Globals.recordingsDeleted)
        {
            Globals.recordingsDeleted = true;
            DeleteRecordings();
        }
    }

    static void DeleteRecordings()
    {
        string[] recordingsFolder = { "Assets/Resources/Recordings" };
        foreach (var asset in AssetDatabase.FindAssets("", recordingsFolder))
        {
            var path = AssetDatabase.GUIDToAssetPath(asset);
            AssetDatabase.DeleteAsset(path);
        }
    }

    // Starts recording first time button is clicked, ends it second time
    public void Record()
    {
        Globals.clickNumber++;

        if (Globals.clickNumber % 2 == 1) // start recording
        {
            Renderer.Rendering = true;
            RecButton.GetComponent<Image>().color = new Color(166f/255f, 0, 0);
        }
        else // end recording
        {
            RecButton.GetComponent<Image>().color = new Color(1, 0, 0);
            EndRecording();
            SaveToTrack(); 
            SceneManager.LoadScene("Tracks");           
        }
    }

    public void EndRecording()
    {
        Renderer.Save("./Assets/Resources/Recordings/recording_" + Globals.clickNumber / 2 + ".wav");
        AssetDatabase.Refresh();
        Renderer.Rendering = false;
    }

    public void SaveToTrack()
    {
        GameObject newTrack = Instantiate(TrackPrefab);
        newTrack.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Recordings/recording_" + Globals.clickNumber / 2);
        AudioClip audioClip = newTrack.GetComponent<AudioClip>();
        newTrack.GetComponent<Track>().ScaleLength();    

        TrackData newTrackData = new TrackData(newTrack.GetComponent<Track>());
        Globals.TrackList.Add(newTrackData);
    }
}