using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioVisualizer : MonoBehaviour
{
	public Transform[] TransformingObjects;
	public int numberOfSamples = 1024; //step by 2
	public FFTWindow fftWindow;
	public float lerpTime = 1;
	public float heightMultiplier;
	
	/*
	 * The intensity of the frequencies found between 0 and 44100 will be
	 * grouped into 1024 elements. So each element will contain a range of about 43.06 Hz.
	 * The average human voice spans from about 60 hz to 9k Hz
	 * we need a way to assign a range to each object that gets animated. that would be the best way to control and modify animatoins.
	*/

	void Update() {

		// initialize our float array
		float[] spectrum = new float [numberOfSamples];
		
		GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, fftWindow);

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
}
