using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrackManager : MonoBehaviour
{
    public GameObject TrackPrefab;

    void Start()
    {
        LoadTracks();
    }

    public void LoadTracks()
    {
        int i = 0;
        foreach (TrackData data in Globals.TrackList)
        {
            GameObject newTrack = Instantiate(TrackPrefab, new Vector3(data.xPos, data.yPos, 0), Quaternion.identity);

            newTrack.GetComponent<Track>().length = data.length;

            AudioSource source = newTrack.GetComponent<AudioSource>();
            source.clip = AudioClip.Create("clip", data.samples.Length, data.channels, data.frequency, false);
            source.clip.SetData(data.samples, 0);
            newTrack.GetComponent<Track>().sound = source.clip;
            newTrack.GetComponent<Track>().trackNumber = i;

            newTrack.GetComponent<Track>().ScaleLength();  
            i++;
        }
    }

    public static void UpdatePositions()
    {
        var allTracks = FindObjectsOfType<Track>();

        foreach (Track track in allTracks)
        {
            TrackData data = Globals.TrackList[track.trackNumber];
            Vector3 p = track.transform.position;

            data.xPos = p.x;
            data.yPos = p.y;
        }
    }

    public void ResetTracks()
    {
        var resetTracks = FindObjectsOfType<Track>();
        
        foreach (Track track in resetTracks)
        {
            Destroy(track.gameObject);
        }

        Globals.TrackList.Clear();
    }
}
