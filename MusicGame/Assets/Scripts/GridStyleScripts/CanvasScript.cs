using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//lol this does nothing

public class CanvasScript : MonoBehaviour
{
    /*
    public AudioSource DrumrollSound;
    public AudioSource BellSound;
    //public AudioSource PianoSound;
    public Button BellButton;
    public Button DrumrollButton;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        BellButton.onClick.AddListener(() => BellCallBack());
        DrumrollButton.onClick.AddListener(() => DrumrollCallBack());
    }

    private void BellCallBack()
    {
        BellSound.Play();
    }
    private void DrumrollCallBack()
    {
        DrumrollSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        var transpose = -4.0f;  // transpose in semitones

            var note = -1.0f; // invalid value to detect when note is pressed
            if (Input.GetKeyDown("a")) note = 0;  // C
            if (Input.GetKeyDown("s")) note = 2;  // D
            if (Input.GetKeyDown("d")) note = 4;  // E
            if (Input.GetKeyDown("f")) note = 5;  // F
            if (Input.GetKeyDown("g")) note = 7;  // G
            if (Input.GetKeyDown("h")) note = 9;  // A
            if (Input.GetKeyDown("j")) note = 11; // B
            if (Input.GetKeyDown("k")) note = 12; // C
            if (Input.GetKeyDown("l")) note = 14; // D

            if (note >= 0)
            { // if some key pressed...
                AudioSource noteToPlay = GetComponent<AudioSource>();

            noteToPlay.pitch = Mathf.Pow(2.0f, (note + transpose) / 12.0f);
            noteToPlay.PlayOneShot(sound,1.0f);
            //noteToPlay.Play();
            }
        }
    */
}
