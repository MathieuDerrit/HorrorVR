using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState _instance;

    public enum Steps { Init,GameStart, InCar, InDomain, InHouse, InSearchingItem, InFightMonster, LastScene, End };
    public Steps _gameStep;
    // Start is called before the first frame update
    void Start()
    {
        _gameStep = Steps.Init;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameStep)
        {
            case Steps.Init:
                SceneManager.LoadScene("Scene_A", LoadSceneMode.Additive);
                _gameStep = Steps.GameStart;
                break;

            case Steps.GameStart:
                break;

            case Steps.InCar:
                break;

            case Steps.InDomain:
                break;

            case Steps.InHouse:
                break;

            case Steps.InSearchingItem:
                break;

            case Steps.InFightMonster:
                break;

            case Steps.LastScene:
                break;

            case Steps.End:
                GameManager._instance._gameState = GameManager.ThisGameState.End;
                break;
        }
    }
}
