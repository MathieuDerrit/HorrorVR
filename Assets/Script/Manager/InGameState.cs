using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameState : MonoBehaviour
{
    public static InGameState _instance;
    public enum InGameSteps { Init,GameStart, InCar, InDomain, InHouse, InSearchingItem, InFightMonster, LastScene, EndGame };
    public InGameSteps _inGameStep;

    private bool _houseOpenned = false;
    private bool _letterFound = false;
    private bool _grabPhone;
    private int _totalPent = 0;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_totalPent);

        switch (_inGameStep)
        {
            case InGameSteps.Init:
                _inGameStep = InGameSteps.GameStart;
                break;

            case InGameSteps.GameStart:
                //en attente de touche puis fondu au noir
                _inGameStep = InGameSteps.InCar;
                break;

            case InGameSteps.InCar:
                if (_grabPhone == true)
                {
                    _inGameStep = InGameSteps.InDomain;
                }
                break;

            case InGameSteps.InDomain:
                /*if (ThisPlank.activated == true)
                {
                    _inGameStep = InGameSteps.InHouse;
                }*/
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
    public void AddPent()
    {
        _totalPent = _totalPent + 1;
    }
}
