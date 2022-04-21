using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrackManager : MonoBehaviour
{
    public GameObject TrackPrefab;
    public static bool TracksReset = false;

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
            GameObject newTrack = Instantiate(TrackPrefab, new Vector3(data.xPos, data.yPos, 0), Quaternion.identity);

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
