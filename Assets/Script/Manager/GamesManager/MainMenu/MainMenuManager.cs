using System.Collections;
using System.Collections.Generic;
using Assets.Script.Manager.MainMenu.States;
using Complete;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Dictionary<MainMenuState, BaseState> _StateDico = new Dictionary<MainMenuState, BaseState>();

    public bool _grabPhone = false;
    public bool _grabRadio = false;
    public bool _grabDoor = false;
    
    public enum MainMenuState
    {
        Choosing,
        Play,
        Settings,
        Quit
    };

    private MainMenuState _currentState;
    private void Awake()
    {
        Choosing ChoosingState = new Choosing();
        Play PlayState = new Play();
        Settings SettingsState = new Settings();
        Quit QuitState = new Quit();

        _StateDico.Add(MainMenuState.Choosing, ChoosingState);
        _StateDico.Add(MainMenuState.Play, PlayState);
        _StateDico.Add(MainMenuState.Settings, SettingsState);
        _StateDico.Add(MainMenuState.Quit, QuitState);
        
        _currentState = MainMenuState.Choosing;
    }
    
    private void Start()
    {
        GetState(_currentState).Enter();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case MainMenuState.Choosing:
                if (_grabPhone)
                {
                    ChangingState(MainMenuState.Play);
                }
                else if (_grabRadio)
                    ChangingState(MainMenuState.Settings);
                else if (_grabDoor)
                    ChangingState(MainMenuState.Quit);
                break;
            
            case MainMenuState.Play:
                
                break;

            case MainMenuState.Settings:
                break;
        }

        GetState(_currentState).UpdateState();
    }

    public void SetGrabPhone(bool isGrabPhone)
    {
        _grabPhone = isGrabPhone;
    }

    public MainMenuState GetCurrentState()
    {
        return _currentState;
    }
    
    private BaseState GetState(MainMenuState State)
    {
        return _StateDico[State];
    }
    
    private void ChangingState(MainMenuState NewState)
    {
        GetState(_currentState).Exit();
        _currentState = NewState;
        GetState(NewState).Enter();
    }
}
