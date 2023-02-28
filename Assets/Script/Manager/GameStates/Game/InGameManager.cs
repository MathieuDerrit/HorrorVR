using System.Collections;
using System.Collections.Generic;
using Assets.Script.Manager.GameStates;
using Script.Manager.GameStates.Game.States;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : BaseGameState
{
    public enum InGameSteps
    {
        Init, 
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

    public InGameManager(string scene) : base(scene)
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

        _currentState = GamesStartState;
    }

    public override void UpdateState()
    {
        switch (_currentState)
        {
            case InGameSteps.Init:
                //Exemple de changement d'état
                if (false) //Condition de changement
                {
                    ChangingState(InGameSteps.GameStart); //Changement de d'état
                }
                break;

            case InGameSteps.GameStart:
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

    public void SetLetterFound(bool newValue)
    {
        _letterFound = newValue;
    }
}
