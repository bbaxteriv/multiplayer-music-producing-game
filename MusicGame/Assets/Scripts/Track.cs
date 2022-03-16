using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private AudioClip sound;
    private float length;


    /*
    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
    */

    public void Start()
    {
        sound = this.GetComponent<AudioSource>().clip;
        length = sound.length;
        Debug.Log(length);

        Vector3 lTemp = transform.localScale;
        lTemp.x *= length;
        transform.localScale = lTemp;
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
    
}