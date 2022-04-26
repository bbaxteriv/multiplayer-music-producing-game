using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class RecordMic : MonoBehaviour
{
	public Transform[] TransformingObjects;
	public int numberOfSamples = 1024;
	public FFTWindow fftWindow;
	public float lerpTime = 1;
	public float heightMultiplier;
	private AudioSource audioSource;
	private string DeviceName;
	private AudioClip audioClip;
	private SavWav sw;
	public GameObject TrackPrefab;
	public Button RecButton;

    // Start is called before the first frame update

	void Start()
	{
		DeviceName = Microphone.devices[0];
		audioSource = GetComponent<AudioSource>();
		Camera MainCamera = Camera.main;
		sw = MainCamera.GetComponent<SavWav>();

		if (!Globals.recordingsDeleted)
        {
            Globals.recordingsDeleted = true;
            DeleteRecordings();
        }
	}

	static void DeleteRecordings()
    {
        string[] recordingsFolder = { "Assets/Resources/Recordings" };
        foreach (var asset in AssetDatabase.FindAssets("", recordingsFolder))
        {
            var path = AssetDatabase.GUIDToAssetPath(asset);
            AssetDatabase.DeleteAsset(path);
        }
    }

	void Update() {

		float[] spectrum = new float [numberOfSamples];

		AudioListener.GetSpectrumData(spectrum, 0, fftWindow);

		// loop over audioSpectrumObjects and modify according to fequency spectrum data
		// this loop matches the Array element to an object on a One-to-One basis.
		for (int i = 0; i < TransformingObjects.Length; i++)
		{
			float intensity = spectrum[i] * heightMultiplier;

			float lerpY = Mathf.Lerp(TransformingObjects[i].localScale.y, intensity, lerpTime);
			Vector3 newScale = new Vector3(TransformingObjects[i].localScale.x, lerpY, TransformingObjects[i].localScale.z);

			TransformingObjects[i].localScale = newScale;
		}
	}

    public void MicRecord()
    {
		Globals.clickNumber++;

		if (Globals.clickNumber % 2 == 1) // start recording
		{
			Microphone.End(DeviceName);
			audioSource.clip = Microphone.Start(DeviceName, true, 3000, 44100);
			Debug.Log(Microphone.IsRecording(DeviceName).ToString());

			if (Microphone.IsRecording(DeviceName)) 
			{
				while (!(Microphone.GetPosition(DeviceName) > 0)) 
				{
				}

				Debug.Log ("recording started with " + DeviceName);
				audioSource.Play();
				RecButton.GetComponent<Image>().color = new Color(166f/255f, 0, 0);
			} 
			else 
			{
				Debug.Log(DeviceName + " doesn't work!");
			}
		}
		else // end recording
		{
            RecButton.GetComponent<Image>().color = new Color(1, 0, 0);
			StopRecord();
			Save();
		}
    }

	public void StopRecord()
	{
		Microphone.End(DeviceName);
		audioClip = sw.TrimSilence(audioSource.clip, 0f);
		sw.Save("./Assets/Resources/Recordings/recording_" + Globals.clickNumber / 2 + ".wav", audioClip);
		AssetDatabase.Refresh();
	}

	// currently not in use
	public void PlayBack()
	{
		audioSource.Play();
	}

	public void Save()
	{
        GameObject newTrack = Instantiate(TrackPrefab);
        newTrack.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Recordings/recording_" + Globals.clickNumber / 2);
        newTrack.GetComponent<Track>().ScaleLength();
        StartCoroutine(LoadTracksScene(newTrack));
	}

	IEnumerator LoadTracksScene(GameObject newTrack)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Tracks", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        SceneManager.MoveGameObjectToScene(newTrack, SceneManager.GetSceneByName("Tracks"));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
