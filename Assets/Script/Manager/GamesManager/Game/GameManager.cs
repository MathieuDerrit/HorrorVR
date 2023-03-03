using System.Collections;
using System.Collections.Generic;
using Complete;
using Script.Manager.GameStates.Game.States;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static MainMenuManager;

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;

    public GameObject canvasCollectPentagram;
    
    public TurnMode _TurnMode;

    public GameObject _XrOrigin;

    [SerializeField] GameObject Pentagram;
    public enum InGameSteps
    {
        GameStart, 
        InCar, 
        InDomain, 
        InHouse, 
        InSearchingItem, 
        InFightMonster, 
        LastScene, 
        EndGame
    };

    public bool _houseOpenned = false;
    public bool _letterFound = false;
    public bool _dollsSuccess = false;
    public bool _candleSuccess = false;

    private InGameSteps _currentState;

    private Dictionary<InGameSteps, BaseState> _StateDico = new Dictionary<InGameSteps, BaseState>();

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        if (_TurnMode == TurnMode.SNAP)
        {
            _XrOrigin.GetComponent<ContinuousTurnProviderBase>().enabled = false;
            _XrOrigin.GetComponent<SnapTurnProviderBase>().enabled = true;
        }
        else
        {
            _XrOrigin.GetComponent<SnapTurnProviderBase>().enabled = false;
            _XrOrigin.GetComponent<ContinuousTurnProviderBase>().enabled = true;
        }
        
        GameStart GamesStartState = new GameStart();
        InCar InCarState = new InCar();
        InDomain InDomainState = new InDomain();
        InHouse InHouseState = new InHouse();
        InSearchingItem InSearchingItemState = new InSearchingItem();
        InFightMonster InFightMonsterState = new InFightMonster();
        LastScene LastSceneState = new LastScene();
        EndGame EndGameState = new EndGame();

        _StateDico.Add(InGameSteps.GameStart, GamesStartState);
        _StateDico.Add(InGameSteps.InCar, InCarState);
        _StateDico.Add(InGameSteps.InDomain, InDomainState);
        _StateDico.Add(InGameSteps.InHouse, InHouseState);
        _StateDico.Add(InGameSteps.InSearchingItem, InSearchingItemState);
        _StateDico.Add(InGameSteps.InFightMonster, InFightMonsterState);
        _StateDico.Add(InGameSteps.LastScene, LastSceneState);
        _StateDico.Add(InGameSteps.EndGame, EndGameState);
        

        _currentState = InGameSteps.InDomain;
    }

    private void Update()
    {
        print(_TurnMode);
        switch (_currentState)
        {
            case InGameSteps.InDomain:
                break;

            case InGameSteps.InHouse:
                if (_letterFound)
                {
                    ChangingState(InGameSteps.InHouse);
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
        
        GetState(_currentState).UpdateState();
    }
    
    private BaseState GetState(InGameSteps State)
    {
        return _StateDico[State];
    }

    public InGameSteps GetCurrentState()
    {
        return _currentState;
    }

    private void ChangingState(InGameSteps NewState)
    {
        GetState(_currentState).Exit();
        _currentState = NewState;
        GetState(NewState).Enter();
    }

    public void SetLetterFound(bool newValue)
    {
        _letterFound = newValue;
    }

    public void InstancePentagram()
    {
        GameObject pent = Instantiate(Pentagram) as GameObject;
        //pent.transform.parent = Player.transform;
    }

    public void EnableUICollectPentagram()
    {
        canvasCollectPentagram.SetActive(true);
    }

    public void DisableUICollectPentagram()
    {
        canvasCollectPentagram.SetActive(false);
    }

    public void ClosingLetter()
    {
        if (!_letterFound)
        {
            InstancePentagram();
            SetLetterFound(true);
        }
    }
}
