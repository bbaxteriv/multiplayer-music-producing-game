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

    // Start is called before the first frame update
    void Start()
    {
        DrumKitButton.onClick.AddListener(() => DrumKitCallBack());
        PianoButton.onClick.AddListener(() => PianoCallBack());
        GridButton.onClick.AddListener(() => GridCallBack());
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


    // Update is called once per frame
    void Update()
    {
        
    }
}




