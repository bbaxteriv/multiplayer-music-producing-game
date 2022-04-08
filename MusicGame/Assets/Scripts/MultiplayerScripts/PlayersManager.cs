using DilmerGames.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Netcode.NetworkBehaviour;

public class PlayersManager : Singleton<PlayersManager>
{
    private NetworkVariable<int> playersInGame = new NetworkVariable<int>();

    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }

    private void Start()
    {
        
        
        NetworkManager.Singleton.OnClientConnectedCallback +=(id) =>
        {
            
            if(IsServer)
            {
                Debug.Log($"{id} just connected...");
                playersInGame.Value++;
            }
            
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            /*
            if (IsServer)
            {
                Debug.Log($"{id} just connected...");
                playersInGame.Value--;
            }
            */
        };
      
    }
        
}
