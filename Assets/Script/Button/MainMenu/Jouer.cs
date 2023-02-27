using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouer : MonoBehaviour
{


    public void startGame()
    {
        ApplicationManager._instance.SetMainGameState(ApplicationManager.MainGameState.InGame);
    }
}
