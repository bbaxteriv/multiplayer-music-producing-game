using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TempTrackSave : MonoBehaviour
{
    public GameObject TrackPrefab;

    public void SaveTracks()
    {
        var allTracks = FindObjectsOfType<Track>();
        int i = 1;
        // TrackSaver.SaveTracks(allTracks[0]);

        foreach (Track track in allTracks)
        {
            TrackSaver.SaveTracks(track, i);
            i++;
        }
    }

    public void LoadTracks()
    {
        DirectoryInfo d = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] files = d.GetFiles();
        int numFiles = files.Length;
        Debug.Log(numFiles);

        for (int i = 1; i <= numFiles; i++)
        {
            TrackData data = TrackSaver.LoadTracks(i);
            GameObject newTrack = Instantiate(TrackPrefab);

            newTrack.GetComponent<Track>().startPosX = data.startPosX;
            newTrack.GetComponent<Track>().startPosY = data.startPosY;
            newTrack.GetComponent<Track>().isBeingHeld = data.isBeingHeld;
            newTrack.GetComponent<Track>().length = data.length;

            AudioSource source = newTrack.GetComponent<AudioSource>();
            source.clip = Resources.Load<AudioClip>("Recordings/recording_" + i); // AudioClip needs to have value before using SetData
            source.clip.SetData(data.samples, 0);
            newTrack.GetComponent<Track>().sound = source.clip;

            newTrack.GetComponent<Track>().ScaleLength();  
        }   
    }
}
