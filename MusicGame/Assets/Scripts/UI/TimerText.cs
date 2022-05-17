using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerText : MonoBehaviour
{
    // public CountdownTimer countdownTimer;
    private Text display;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = DisplayTime(Globals.timer);

        if (SceneManager.GetActiveScene().name == "Voting")
        {
            Destroy(gameObject);
        }

        if (Globals.timer > 0)
        {
            Globals.timer -= Time.smoothDeltaTime;
        }
        else
        {
            SceneManager.LoadScene("Voting");
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
