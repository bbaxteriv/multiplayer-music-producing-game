using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceScript : MonoBehaviour
{
    public GameObject bar;
    private float songLength;
    private Vector3 storedLength;
    private Vector3 storedPosition = new Vector3(6.5f, 3.99f, 0f);
    private float xPos = 6f;

    // Start is called before the first frame update
    void Start()
    {
        storedLength = transform.localScale;
        storedLength.x = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lTemp = storedLength;
        songLength = bar.GetComponent<MusicBar>().length;

        lTemp.x *= songLength;

        transform.localScale = lTemp;

        xPos = ((songLength - 1f) / 2f);

        storedPosition = new Vector3(xPos, 3.99f, 0f);

        transform.localPosition = storedPosition;
    }
}




