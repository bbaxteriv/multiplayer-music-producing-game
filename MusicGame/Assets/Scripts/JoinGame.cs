using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JoinGame : MonoBehaviour
{
    public Button joinGameButton;
    public Text gameID;
    public Text gameName;

    // Start is called before the first frame update
    void Start()
    {
      joinGameButton.onClick.AddListener(() => joinGame());
    }


    // create new game and display id when button is pressed
    void joinGame()
    {
      string name = gameName.text;
      int id;
      int.TryParse(gameID.text, out id);
      bool success = joinGame(name, id);
      if (success)
      {
        Debug.Log("success\nname: " + name + "\nid: " + id.ToString());
      }
      else
      {
        Debug.Log("failed to join game\nname: " + name + "\nid: " + id.ToString());
      }
    }


    bool joinGame(string name, int id)
    {
      // check for game through sql
      // add player to game
      /*
      results = SELECT id FROM music_game_games WHERE name = ? and id = ?;
      names = SELECT name FROM music_game_players WHERE game_id = ?;
      if name in names
        name in use
      if length results == 1
        INSERT INTO music_game_players (name, game_id) VALUES(?, ?);
      else
        password or name is incorrect
      */
      //to complete later
      return false;
    }
}
