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
    public static bool RecordingsDeleted = false;

    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = Camera.main;
        Renderer = MainCamera.GetComponent<AudioRenderer>();
        Renderer.Rendering = false;

        if (!RecordingsDeleted)
        {
            RecordingsDeleted = true;
            DeleteRecordings();
        }

        Debug.Log(Globals.clickNumber);
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
        }
    }

    public void EndRecording()
    {
        Renderer.Save("./Assets/Resources/Recordings/recording_" + Globals.clickNumber / 2 + ".wav"); // the random notes playing is because when the file gets overwritten, it doesn't get erased first, so stuff at the end stays
        AssetDatabase.Refresh();
        Renderer.Rendering = false;
    }

    public void SaveToTrack()
    {
        GameObject newTrack = Instantiate(TrackPrefab);
        newTrack.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Recordings/recording_" + Globals.clickNumber / 2);
        newTrack.GetComponent<Track>().ScaleLength();
        StartCoroutine(LoadTracksScene(newTrack));
    }

    IEnumerator LoadTracksScene(GameObject newTrack)
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