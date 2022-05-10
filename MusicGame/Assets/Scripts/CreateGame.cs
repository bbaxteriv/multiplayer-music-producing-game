using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateGame : MonoBehaviour
{
    public Button createGameButton;
    public Text gameID;
    public Text gameName;

    // Start is called before the first frame update
    void Start()
    {
      createGameButton.onClick.AddListener(() => createGame());
    }


    // create new game and display id when button is pressed
    void createGame()
    {
      string name = gameName.text;
      int id = getGameID();
      gameID.text = id.ToString();

    }


    int getGameID()
    {
      // create game through sql
      // add player to game
      /*
      INSERT INTO music_game_games (name) VALUES(?, ?);
      SELECT LAST_INSERT_ID() FROM music_game_games;
      add current user to game
        INSERT INTO music_game_players (name, game_id) VALUES (?, ?)
      */
      //to complete later
      return -1;
    }
}
