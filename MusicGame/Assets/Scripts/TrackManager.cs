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
            newTrack.GetComponent<Track>().trackNumber = i; // list order is always the same, so each track always gets the same trackNumber

            newTrack.GetComponent<Track>().ScaleLength();  
            i++;
        }
    }

    public static void UpdatePositions() // when you delete a track from the tracklist the numbers don't match up anymore
    {
        var allTracks = FindObjectsOfType<Track>();
        // works properly for deleting the most recent track, but not tracks that were recorded prior
        // figure out how to change indexes for tracks that came after recorded tracks

        // check how many items in deletedTracks trackNumber is greater than, then shift the index that many times to the left
        foreach (Track track in allTracks)
        {
            if (!Globals.deletedTracks.Contains(track.trackNumber)) // doesn't save data for deleted tracks
            {
                int leftShift = 0; // makes sure that every space in TrackList is filled
                foreach (int i in Globals.deletedTracks)
                {
                    if (track.trackNumber > i)
                    {
                        leftShift++;
                    }
                }

                TrackData data = Globals.TrackList[track.trackNumber - leftShift]; // if you delete track 0, then it immediately goes to add a track at position 1 without filling 0
                Vector3 p = track.transform.position; // DeleteTrack() in the track class deletes it from the track list, so you might be filling an index with the wrong data

                data.xPos = p.x;
                data.yPos = p.y;
            }
        }

        Globals.deletedTracks.Clear();
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
