using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.timer > 0)
        {
            Globals.timer -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Voting");
        }

        if (SceneManager.GetActiveScene().name == "Voting")
        {
            Destroy(gameObject);
        }
    }

    public string DisplayTime(float timer)
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.CeilToInt(timer % 60);
        string timerText = string.Format("{0:00}:{1:00}", minutes, seconds - 1);

        return timerText;
    }
}
