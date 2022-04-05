using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackData
{
    public float startPosX;
    public float startPosY;
    public bool isBeingHeld;
    public float[] samples;
    public float length;

    public TrackData(Track track)
    {
        startPosX = track.startPosX;
        startPosY = track.startPosY;
        isBeingHeld = track.isBeingHeld;
        length = track.length;

        AudioSource audioSource = track.GetComponent<AudioSource>();
        samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);
    }
}
