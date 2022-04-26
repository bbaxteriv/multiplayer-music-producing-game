using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackData
{
    public float xPos; // startposx isn't always the current position
    public float yPos;
    public float[] samples;
    public float length;
    public int channels;
    public int frequency;

    public TrackData(Track track)
    {
        Vector3 p = track.transform.position;
        xPos = p.x;
        yPos = p.y;
        
        length = track.length;

        AudioSource audioSource = track.GetComponent<AudioSource>();
        samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);

        channels = audioSource.clip.channels;
        frequency = audioSource.clip.frequency;
    }
}
