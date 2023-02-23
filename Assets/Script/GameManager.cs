using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public enum ThisGameState {Init, Mainmenu,StartGame, InGame, End};
    public ThisGameState _gameState;
    // Start is called before the first frame update
    void Start()
    {
        _gameState = ThisGameState.Init;
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case ThisGameState.Init:
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                _gameState = ThisGameState.Mainmenu;
                break;

            case ThisGameState.Mainmenu:
                break;

            case ThisGameState.StartGame:
                GameState NewGame;
                _gameState = ThisGameState.InGame;
                break;

            case ThisGameState.InGame:

                break;

            case ThisGameState.End:
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                _gameState = ThisGameState.Mainmenu;
                break;
        }
    }
}
