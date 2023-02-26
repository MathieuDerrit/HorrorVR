using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState _instance;
    public enum InGameSteps { Init,GameStart, InCar, InDomain, InHouse, InSearchingItem, InFightMonster, LastScene, EndGame };
    public InGameSteps _inGameStep;

    private bool _houseOpenned = false;
    private bool _letterFound = false;
    private bool _grabPhone;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        _inGameStep = InGameSteps.Init;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_inGameStep)
        {
            case InGameSteps.Init:
                _inGameStep = InGameSteps.GameStart;
                break;

            case InGameSteps.GameStart:
                break;

            case InGameSteps.InCar:
                if (_grabPhone == true)
                {
                    _inGameStep = InGameSteps.InDomain;
                }
                break;

            case InGameSteps.InDomain:
                if (_houseOpenned == true)
                {
                    _inGameStep = InGameSteps.InHouse;
                }
                break;

            case InGameSteps.InHouse:
                if (_letterFound == true)
                {
                    _inGameStep = InGameSteps.InHouse;
                }
                break;

            case InGameSteps.InSearchingItem:
                break;

            case InGameSteps.InFightMonster:
                break;

            case InGameSteps.LastScene:
                break;

            case InGameSteps.EndGame:
                GameManager._instance.SetMainGameState(GameManager.MainGameState.End);
                break;
        }
    }

    public void SetHouseOpen(bool newValue)
    {
        _houseOpenned = newValue;
    }
    public void SetLetterFound(bool newValue)
    {
        _letterFound = newValue;
    }
}
