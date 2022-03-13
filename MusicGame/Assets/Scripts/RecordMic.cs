using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMic : MonoBehaviour
{
	private AudioSource audioSource;
	private string DeviceName;
    // Start is called before the first frame update
	
	void Start()
	{
		DeviceName = Microphone.devices[0];
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
    void Update()
    {

    }
	
    public void StartRecord()
    {
		audioSource.clip = Microphone.Start(DeviceName, true, 100, 44100);
    }
	
	public void StopRecord()
	{
		Microphone.End(DeviceName);
	}
	public void PlayBack()
	{
		audioSource.Play();
	}
	
	
}
