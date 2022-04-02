using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button startServerButton;
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;
    [SerializeField] private TextMeshProUGUI playersInGameText;

    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //playersInGameText.text = $"Players in game: {PlayersManager.Instance.PlayersInGame}";
    }
    
    private void Start()
    {
        /*
        startHostButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {
                Logger.Instance.LogInfo("Host started...");
            }
            else
            {

            }
        });
        startServerButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartServer())
            {

            }
            else
            {

            }
        });
        startClientButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {

            }
            else
            {

            }
        });
        */
    }
    
}
