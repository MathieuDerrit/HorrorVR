using System.Collections;
using System.Collections.Generic;
using Complete;
using Script.Manager.GameStates.Game.States;
using UnityEngine;
using static MainMenuManager;

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;
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

    private bool _houseOpenned = false;
    private bool _letterFound = false;
    private bool _dollsSuccess = false;

    private InGameSteps _currentState;

    private Dictionary<InGameSteps, BaseState> _StateDico = new Dictionary<InGameSteps, BaseState>();

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
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

        _currentState = InGameSteps.GameStart;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case InGameSteps.GameStart:
                //Exemple de changement d'état
                if (false) //Condition de changement
                {
                    ChangingState(InGameSteps.GameStart); //Changement de d'état
                }
                break;

            case InGameSteps.InCar:

                break;

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
}
