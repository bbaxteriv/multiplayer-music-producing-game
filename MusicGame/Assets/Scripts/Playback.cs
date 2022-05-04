using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playback : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // set audio source as export clip
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Exports/export"); // make file unique to game id
    }

    public void PreviewClip()
    {
        audioSource.Play();
    }
}
