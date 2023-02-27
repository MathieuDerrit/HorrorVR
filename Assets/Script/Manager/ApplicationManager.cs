using Assets.Script.Manager.GameStates;
using Assets.Script.Manager.MainMenu.States;
using Complete;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static MainMenuManager;

public class ApplicationManager : MonoBehaviour
{

    public enum MainGameState 
    {
        Init, 
        MainMenu, 
        StartGame, 
        InGame, 
        End
    };

    [SerializeField] private MainGameState _mainGameState;
    protected Dictionary<MainGameState, BaseGameState> _StateDico = new Dictionary<MainGameState, BaseGameState>();

    private BaseGameState GetState(MainGameState State)
    {
        return _StateDico[State];
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        MainMenuManager MainMenu = new MainMenuManager();

        _StateDico.Add(MainGameState.MainMenu, MainMenu);
        _mainGameState = MainGameState.MainMenu;
    }

    // Start is called before the first frame update
    void Start()
    {
        //_mainGameState = MainGameState.MainMenu;
        GetState(_mainGameState).Enter();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_mainGameState)
        {
            case MainGameState.Init:
                //SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                //_mainGameState = MainGameState.Mainmenu;
                break;

            case MainGameState.MainMenu:
                /*SceneManager.LoadScene("Scene_A", LoadSceneMode.Additive);
                _mainGameState = MainGameState.MainMenu;*/
                break;

            case MainGameState.StartGame:
                //_mainGameState = MainGameState.InGame;
                break;

            case MainGameState.InGame:

                break;

            case MainGameState.End:
                /*SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                _mainGameState = MainGameState.MainMenu;*/
                break;
        }
        
        GetState(_mainGameState).UpdateState();
    }
    public void SetMainGameState(MainGameState newState)
    {
        GetState(_mainGameState).Exit();
        _mainGameState = newState;
        GetState(newState).Enter();
        
    }
}
