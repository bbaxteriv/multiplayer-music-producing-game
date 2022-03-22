using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public Button DrumKitButton;
    public Button PianoButton;
    public Button GridButton;
    public Button HarpButton;
    public Button GuitarButton;
	  public Button MicButton;
    public Button TracksButton;

    // Start is called before the first frame update
    void Start()
    {
        DrumKitButton.onClick.AddListener(() => DrumKitCallBack());
        PianoButton.onClick.AddListener(() => PianoCallBack());
        GridButton.onClick.AddListener(() => GridCallBack());
        HarpButton.onClick.AddListener(() => HarpCallBack());
        GuitarButton.onClick.AddListener(() => GuitarCallBack());
		    MicButton.onClick.AddListener(() => MicCallBack());
        TracksButton.onClick.AddListener(() => TracksCallBack());

	   }
    private void DrumKitCallBack()
    {
        SceneManager.LoadScene("DrumKit");
    }
    private void PianoCallBack()
    {
        SceneManager.LoadScene("Piano");
    }
    private void GridCallBack()
    {
        SceneManager.LoadScene("Grid");
    }
    private void HarpCallBack()
    {
        SceneManager.LoadScene("Harp");
    }
    private void GuitarCallBack()
    {
        SceneManager.LoadScene("Guitar");
    }
  	private void MicCallBack()
  	{
  		  SceneManager.LoadScene("Microphone");
  	}
    private void TracksCallBack()
  	{
  		  SceneManager.LoadScene("Tracks");
  	}

    // Update is called once per frame
    void Update()
    {

    }
}
