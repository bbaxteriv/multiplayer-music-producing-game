using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordMic : MonoBehaviour
{
	public Transform[] TransformingObjects;
	public int numberOfSamples = 1024; //step by 2
	public FFTWindow fftWindow;
	public float lerpTime = 1;
	public float heightMultiplier;
	private AudioSource audioSource;
	private string DeviceName;
    // Start is called before the first frame update
	
	void Start()
	{
		DeviceName = Microphone.devices[0];
		audioSource = GetComponent<AudioSource> ();
	}
	
	void Update() {

		// initialize our float array
		float[] spectrum = new float [numberOfSamples];
		
		AudioListener.GetSpectrumData(spectrum, 0, fftWindow);

		// loop over audioSpectrumObjects and modify according to fequency spectrum data
		// this loop matches the Array element to an object on a One-to-One basis.
		for(int i = 0; i < TransformingObjects.Length; i++)
		{
			float intensity = spectrum[i] * heightMultiplier;
			
			float lerpY = Mathf.Lerp(TransformingObjects[i].localScale.y, intensity, lerpTime);
			Vector3 newScale = new Vector3(TransformingObjects[i].localScale.x, lerpY, TransformingObjects[i].localScale.z);
			
			TransformingObjects[i].localScale = newScale;
		}
	}
	
    public void StartRecord()
    {
		Microphone.End(DeviceName);
		audioSource.clip = Microphone.Start(DeviceName, true, 3000, 44100);
		
		Debug.Log(Microphone.IsRecording(DeviceName).ToString());

		if (Microphone.IsRecording (DeviceName)) { //check that the mic is recording, otherwise you'll get stuck in an infinite loop waiting for it to start
			while (!(Microphone.GetPosition (DeviceName) > 0)) {
			} // Wait until the recording has started. 
		
			Debug.Log ("recording started with " + DeviceName);
			// Start playing the audio source
			audioSource.Play (); 
		} else {
			//microphone doesn't work for some reason

			Debug.Log (DeviceName + " doesn't work!");
		}


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
