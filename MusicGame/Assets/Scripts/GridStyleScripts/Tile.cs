using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public AudioSource PianoSound;
    public AudioClip sound;
    public Button ClearButton;
    private int ypos;

    // Start is called before the first frame update
    //public void Init()
    //{

    //}

    // Update is called once per frame

    void Start()
    {
        ClearButton.onClick.AddListener(() => ClearCallBack());
    }

    private void ClearCallBack()
    {
        _highlight.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ypos = int.Parse(gameObject.name.Split(' ')[2]);
        var transpose = -4.0f;  // transpose in semitones

        var note = -1.0f; // invalid value to detect when note is pressed
        
        if (ypos == 0) note = 0;  // C
        if (ypos == 1) note = 2;  // D
        if (ypos == 2) note = 4;  // E
        if (ypos == 3) note = 5;  // F
        if (ypos == 4) note = 7;  // G
        if (ypos == 5) note = 9;  // A
        if (ypos == 6) note = 11; // B
        if (ypos == 7) note = 12; // C
        if (ypos == 8) note = 14; // D
        
        if (note >= 0 && _highlight.activeSelf)
        { // if some key pressed...
            AudioSource noteToPlay = GetComponent<AudioSource>();

            noteToPlay.pitch = Mathf.Pow(2.0f, (note + transpose) / 12.0f);
            noteToPlay.PlayOneShot(sound, 1.0f);
        }
    }

    void OnMouseDown()
    {
        if (_highlight.activeSelf)
        {
            _highlight.SetActive(false);
        }
        else
        {
            _highlight.SetActive(true);
        }
    }
}
