using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private MainMenuManager _MainMenuManager; 
        
    public void backToMainMenu()
    {
        _MainMenuManager._backToMenu = true;
    }
    
    public void HandleInputData(int select)
    {
        if (select == 0)
        {
            _MainMenuManager._TurnMode = MainMenuManager.TurnMode.SNAP;
        }
        else if(select == 1)
        {
            _MainMenuManager._TurnMode = MainMenuManager.TurnMode.CONTINUOUS;
        }
    }
}
