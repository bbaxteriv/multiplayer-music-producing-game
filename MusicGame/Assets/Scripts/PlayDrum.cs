using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDrum : MonoBehaviour
{
    void OnMouseDown()
	{
		GetComponent<AudioSource>().Play();
	}
}
