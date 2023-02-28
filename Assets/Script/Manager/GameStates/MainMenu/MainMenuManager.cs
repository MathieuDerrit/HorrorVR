using Assets.Script.Manager.GameStates;
using Assets.Script.Manager.MainMenu.States;
using Complete;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : BaseGameState
{
    // Start is called before the first frame update

    public Image FadeImage;
    public float Duration;

    //public MainMenuState _currentState;

    public enum MainMenuState
    {
        Choosing,
        Play,
        Settings,
        Quit
    };
    
    public MainMenuManager(string scene) : base(scene)
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
    
    public override void Enter()
    {
        GetState(_currentState).Enter();
    }

    public override void UpdateState()
    {
        switch (_currentState)
        {
            case MainMenuState.Choosing:
                break;

            case MainMenuState.Play:
                break;

            case MainMenuState.Settings:
                break;

            case MainMenuState.Quit:
                break;
        }

        GetState(_currentState).UpdateState();
    }

}
