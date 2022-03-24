using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            RecButton.GetComponent<Image>().color = new Color(1, 0, 0);
            EndRecording();
            SaveToTrack();
        }
    }

    public void EndRecording()
    {
        Renderer.Save("./Assets/Resources/Recordings/recording_" + clickNumber / 2 + ".wav");
        Renderer.Rendering = false;

        AudioClip clipped = Resources.Load<AudioClip>("Recordings/recording_" + clickNumber / 2);
    }

    // figure out how to create newTrack in the Tracks scene
    public void SaveToTrack()
    {
        GameObject newTrack = Instantiate(TrackPrefab);

        //float length = clipped.length;

        //Debug.Log(length);

        Debug.Log(newTrack.GetComponent<AudioSource>().clip.loadState);

        /*
        while (newTrack.GetComponent<AudioSource>().clip.loadState != AudioDataLoadState.Loaded)
        {
            Debug.Log("Waiting to load audio clip.");
        }
        */

        newTrack.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Recordings/recording_" + clickNumber / 2);

        newTrack.GetComponent<Track>().ScaleLength();

        StartCoroutine(LoadTracks(newTrack));

        
    }

    IEnumerator LoadTracks(GameObject newTrack)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Tracks", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(newTrack, SceneManager.GetSceneByName("Tracks"));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}