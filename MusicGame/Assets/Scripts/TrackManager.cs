using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrackManager : MonoBehaviour
{
    public GameObject TrackPrefab;
    public static bool TracksReset = false;
    private int _width = 16;
    private int _height = 9;

    void Start()
    {
        if (!TracksReset)
        {
            TracksReset = true;

            DirectoryInfo d = new DirectoryInfo(Application.persistentDataPath);
            FileInfo[] files = d.GetFiles();
            int numFiles = files.Length;

            for (int i = 1; i <= numFiles; i++)
            {
                File.Delete(Application.persistentDataPath + "/track_" + i + ".txt");
            }   
        }
    }

    public void SaveTracks()
    {
        var allTracks = FindObjectsOfType<Track>();
        int i = 1;

        foreach (Track track in allTracks)
        {
            TrackSaver.SaveTracks(track, i);
            i++;
        }
    }

    public void LoadTracks()
    {
        // ResetTracks();

        DirectoryInfo d = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] files = d.GetFiles();
        int numFiles = files.Length;

        for (int i = 1; i <= numFiles; i++)
        {
            TrackData data = TrackSaver.LoadTracks(i);
            GameObject newTrack = Instantiate(TrackPrefab, new Vector3((float)_width / 2 - 0.5f + data.startPosX, (float)_height / 2 - 0.5f + data.startPosY, 0), Quaternion.identity); // weird positions because camera is moved in tracks scene

            newTrack.GetComponent<Track>().length = data.length;

            AudioSource source = newTrack.GetComponent<AudioSource>();
            source.clip = Resources.Load<AudioClip>("Recordings/recording_" + i); // AudioClip needs to have value before using SetData
            source.clip.SetData(data.samples, 0);
            newTrack.GetComponent<Track>().sound = source.clip;

            newTrack.GetComponent<Track>().ScaleLength();  
        }   
    }

    public void ResetTracks()
    {
        var resetTracks = FindObjectsOfType<Track>();
        
        foreach (Track track in resetTracks)
        {
            Destroy(track.gameObject);
        }
    }
}
