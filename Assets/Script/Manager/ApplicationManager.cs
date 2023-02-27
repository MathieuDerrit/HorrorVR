using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager _instance;

    public enum MainGameState {Init, Mainmenu,StartGame, InGame, End};
    [SerializeField] private MainGameState _mainGameState;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _mainGameState = MainGameState.Init;
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_mainGameState)
        {
            case MainGameState.Init:
                //SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                _mainGameState = MainGameState.Mainmenu;
                break;

            case MainGameState.Mainmenu:
                break;

            case MainGameState.StartGame:
                SceneManager.LoadScene("Scene_A", LoadSceneMode.Additive);
                _mainGameState = MainGameState.InGame;
                break;

            case MainGameState.InGame:

                break;

            case MainGameState.End:
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                _mainGameState = MainGameState.Mainmenu;
                break;
        }
    }
    public void SetMainGameState(MainGameState newValue)
    {
        _mainGameState = newValue;
    }
}
