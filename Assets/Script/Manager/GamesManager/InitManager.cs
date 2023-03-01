using System.Collections;
using System.Collections.Generic;
using Complete;
using Script.Manager.GameStates.Game.States;
using UnityEngine;
using UnityEngine.InputSystem;
using static MainMenuManager;

public class InitManager : MonoBehaviour
{
    public enum InitStates
    {
        Init,
        MainMenu
    };

    public Input _intpurprop;

    private bool _houseOpenned = false;
    private bool _letterFound = false;

    private InitStates _currentState;

    private Dictionary<InitStates, BaseState> _StateDico = new Dictionary<InitStates, BaseState>();

    private void Start()
    {
        /*GameStart GamesStartState = new GameStart();
        InCar InCarState = new InCar();

        _StateDico.Add(InGameSteps.Init, "StatGame");
        _StateDico.Add(InGameSteps.MainMenu, "MainMenu");*/

        _currentState = InitStates.Init;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case InitStates.Init:
                if (Input.anyKeyDown)
                {
                    ChangingState(InitStates.MainMenu);
                }
                break;
        }
        

        //GetState(_currentState).UpdateState();

    }

    public InitStates GetCurrentState()
    {
        return _currentState;
    }

    private BaseState GetState(InitStates State)
    {
        return _StateDico[State];
    }

    private void ChangingState(InitStates NewState)
    {
        //GetState(_currentState).Exit();
        _currentState = NewState;
        //GetState(NewState).Enter();
    }

    public void SetLetterFound(bool newValue)
    {
        _letterFound = newValue;
    }
}



