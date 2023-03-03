using System.Collections;
using System.Collections.Generic;
using Assets.Script.Manager.MainMenu.States;
using Complete;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Dictionary<MainMenuState, BaseState> _StateDico = new Dictionary<MainMenuState, BaseState>();
    [HideInInspector]
    public bool _grabPhone = false;
    [HideInInspector]
    public bool _grabRadio = false;
    [HideInInspector]
    public bool _grabDoor = false;
    [HideInInspector]
    public bool _endTalk = false;

    [SerializeField]
    private GameObject _Player;

    [SerializeField]
    private Transform _StartLocation;

    [SerializeField]
    private Transform _EndLocation;


    public float _endFadingTime;
   
    public List<TextMeshProUGUI> textMeshProsUI = new List<TextMeshProUGUI>();

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
        _Player.transform.SetPositionAndRotation(_StartLocation.position, _StartLocation.rotation);
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
                    Play State = (Play)GetState(_currentState);

                    foreach (TextMeshProUGUI text in textMeshProsUI)
                    {
                        print("ENTERTEXTE");
                        StartCoroutine(State.FadeAll(text, _endFadingTime));
                    }
                }
                else if (_grabRadio)
                {
                    print("okkkkk");
                    ChangingState(MainMenuState.Settings);
                    _Player.transform.SetPositionAndRotation(_EndLocation.position, _EndLocation.rotation);
                }
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

    public void SetSelectRadio(bool isSelectRadio)
    {
        _grabRadio = isSelectRadio;
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
