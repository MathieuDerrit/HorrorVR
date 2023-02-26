using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameState : MonoBehaviour
{
    public static InGameState _instance;
    public enum InGameSteps { Init,GameStart, InCar, InDomain, InHouse, InSearchingItem, InFightMonster, LastScene, EndGame };
    public InGameSteps _inGameStep;

    [SerializeField] private bool _letterFound = false;
    [SerializeField] public PlankToDestroy ThisPlank;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_inGameStep)
        {
            case InGameSteps.Init:
                //init de la game
                _inGameStep = InGameSteps.GameStart;
                break;

            case InGameSteps.GameStart:
                //en attente de touche puis fondu au noir
                _inGameStep = InGameSteps.InCar;
                break;

            case InGameSteps.InCar:
                
                break;

            case InGameSteps.InDomain:
                if (ThisPlank.activated == true)
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
                
                break;
        }
    }

    public void SetLetterFound(bool newValue)
    {
        _letterFound = newValue;
    }
}
