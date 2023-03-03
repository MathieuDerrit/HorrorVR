using Assets.Script.Manager.GameStates;
using Assets.Script.Manager.MainMenu.States;
using Complete;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Manager.GameStates.End;
using Assets.Script.Manager.GameStates.Init;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static MainMenuManager;
using static InitManager;
using static GameManager;
using static UnityEngine.UI.CanvasScaler;
using UnityEngine.InputSystem.LowLevel;

public class AppSceneManager : MonoBehaviour
{
    public static AppSceneManager instance;
    public enum MainGameState
    {
        Init,
        MainMenu,
        InGame,
        End
    };

    [SerializeField] 
    private MainGameState _currentGameState;
    
    private TurnMode _turnMode;

    public GameObject GameManager;
    protected Dictionary<MainGameState, string> _StateDico = new Dictionary<MainGameState, string>();

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            _StateDico.Add(MainGameState.Init, "StartScene");
            _StateDico.Add(MainGameState.MainMenu, "MainMenu");
            _StateDico.Add(MainGameState.InGame, "Scene_A");
            _StateDico.Add(MainGameState.End, "null");
            
            _currentGameState = MainGameState.Init;
        }
    }

    private void Start()
    {
        SceneManager.LoadScene("StartScene");
    }
    
    private void Update()
    {
        switch (_currentGameState)
        {
            case MainGameState.Init:
                if(GameManager != null)
                {
                    if (GameManager.GetComponent<InitManager>().GetCurrentState() == InitStates.MainMenu)
                    {
                        SetMainGameState(MainGameState.MainMenu, LoadSceneMode.Single);
                    }
                }else
                    GameManager = GameObject.Find("InitManager");

                break;

            case MainGameState.MainMenu:
                if (GameManager != null)
                {
                    if (GameManager.GetComponent<MainMenuManager>().GetCurrentState() == MainMenuState.Play)
                    {
                        _turnMode = GameManager.GetComponent<MainMenuManager>()._TurnMode;
                        SetMainGameState(MainGameState.InGame);
                    }
                }else
                    GameManager = GameObject.Find("MainMenuManager");

                break;

            case MainGameState.InGame:
                if (GameManager != null)
                {
                    if (GameManager.GetComponent<MainMenuManager>() != null)
                    {
                        if (GameManager.GetComponent<MainMenuManager>()._endTalk)
                        {
                            SetMainGameState(MainGameState.InGame, LoadSceneMode.Single, MainGameState.MainMenu);
                        }
                    }else if(GameManager.GetComponent<GameManager>() != null)
                    {
                        GameManager.GetComponent<GameManager>()._TurnMode = _turnMode;
                        if (GameManager.GetComponent<GameManager>().GetCurrentState() == InGameSteps.EndGame)
                        {
                            SetMainGameState(MainGameState.End, LoadSceneMode.Single);
                        }
                    }
                }
                else
                    GameManager = GameObject.Find("GameManager");
                break;

            case MainGameState.End:
                break;
        }
    }

    private string GetState(MainGameState State)
    {
        return _StateDico[State];
    }

    private void SetMainGameState(MainGameState newState)
    {
        _currentGameState = newState;
    }

    private void SetMainGameState(MainGameState newState, LoadSceneMode sceneMode)
    {
        SceneManager.UnloadSceneAsync(GetState(_currentGameState));
        _currentGameState = newState;
        SceneManager.LoadScene(GetState(_currentGameState), sceneMode);
    }
    
    private void SetMainGameState(MainGameState newState, LoadSceneMode sceneMode, MainGameState lastState)
    {
        SceneManager.UnloadSceneAsync(GetState(lastState));
        _currentGameState = newState;
        SceneManager.LoadScene(GetState(_currentGameState), sceneMode);
    }

    public void GoToMenu()
    {
        StartCoroutine(GoToMenuCouroutine());
    }

    IEnumerator GoToMenuCouroutine()
    {
        yield return new WaitForSeconds(3);
        SetMainGameState(MainGameState.MainMenu, LoadSceneMode.Single);
    }
}