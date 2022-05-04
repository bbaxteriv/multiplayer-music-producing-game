using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RecordFinal : MonoBehaviour
{
    private AudioRenderer Renderer;
    public Button RecButton;
    private int clickNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = Camera.main;
        Renderer = MainCamera.GetComponent<AudioRenderer>();
        Renderer.Rendering = false;
    }

    public void Record()
    {
        clickNumber++;

        if (clickNumber % 2 == 1)
        {
            string[] exportsFolder = { "Assets/Resources/Exports" }; // wipe exports folder when starting a new recording to avoid overwriting errors
            foreach (var asset in AssetDatabase.FindAssets("", exportsFolder))
            {
                var path = AssetDatabase.GUIDToAssetPath(asset);
                AssetDatabase.DeleteAsset(path);
            }
            
            Renderer.Rendering = true;
            RecButton.GetComponent<Image>().color = new Color(166f/255f, 0, 0);
        }
        else
        {
            RecButton.GetComponent<Image>().color = new Color(1, 0, 0);
            EndRecording();
        }
    }

    public void EndRecording()
    {
        Renderer.Save("./Assets/Resources/Exports/export.wav"); // unique identifier on these files with game id?
        AssetDatabase.Refresh();
        Renderer.Rendering = false;
        SceneManager.LoadScene("Preview");
    }
}
