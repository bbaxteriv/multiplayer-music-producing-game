using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Track : MonoBehaviour
{
    public float startPosX;
    public float startPosY;
    public bool isBeingHeld = false;
    public AudioClip sound;
    public float length;
    public int trackNumber;
    public float constantLengthFactor = 1.15f;

    private GameObject bar;
    private float barSpeed;
    private Vector3 storedLength;
    private Vector3 newLength;

    private void Awake()
    {
        bar = GameObject.Find("MusicBar");
    }

    public void Update()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (isBeingHeld == true)
        {
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }

        barSpeed = bar.GetComponent<MusicBar>().speed;

        newLength = storedLength;
        newLength.x *= (barSpeed / 2f);

        transform.localScale = newLength;
    }

    public void ScaleLength()
    {
        sound = this.GetComponent<AudioSource>().clip;
        length = sound.length;

        length *= constantLengthFactor;

        Vector3 lTemp = transform.localScale;
        lTemp.x *= length;

        storedLength = lTemp;

        transform.localScale = lTemp;
    }

    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;
        }
    }
    
    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isBeingHeld = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource noteToPlay = GetComponent<AudioSource>();

        noteToPlay.PlayOneShot(sound, 1.0f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Trash" && !Input.GetMouseButton(0))
        {
            DeleteTrack();
        }
    }
    
    public void DeleteTrack()
    {
        Globals.TrackList.RemoveAt(trackNumber);
        Globals.deletedTracks.Add(trackNumber);
        Destroy(gameObject);
    }
}
