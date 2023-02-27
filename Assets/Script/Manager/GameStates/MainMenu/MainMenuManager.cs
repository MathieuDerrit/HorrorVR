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
using static ApplicationManager;

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


    public override void Enter()
    {

        Choosing ChoosingState = new Choosing();
        Settings SettingsState = new Settings();

        _StateDico.Add(MainMenuState.Choosing, ChoosingState);
        _StateDico.Add(MainMenuState.Choosing, SettingsState);
        /*_StateDico.Add(MainMenuState.Play, ReloadState);
        _StateDico.Add(MainMenuState.Settings, WaitState);
        _StateDico.Add(MainMenuState.Quit, WaitState);*/

        _currentState = MainMenuState.Choosing;
    }

    void Start()
    {
        ChangingState<MainMenuState>(_currentState, MainMenuState.Choosing);
        /*StopAllCoroutines();
        StartCoroutine(Fade(Duration));*/
    }

    // Update is called once per frame
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

        GetState(_currentState);
    }

    /*private void ChangingState(MainMenuState NewState)
    {
        GetState(_currentState).Exit();
        _currentState = NewState;
        GetState(NewState).Enter();
    }*/

    /*private IEnumerator Fade(float Time)
    {
        float nbrOfTime = Time / 0.1f;
        float fadeSubstract = 1.0f / nbrOfTime;
        for (int i = 0; i < nbrOfTime; i++)
        {
            yield return new WaitForSeconds(0.1f);
            float alpha = FadeImage.color.a - fadeSubstract;
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);
        }
    }*/

}
