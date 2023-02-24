using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouer : MonoBehaviour
{


    public void startGame()
    {
        GameManager._instance.SetMainGameState(GameManager.MainGameState.InGame);
    }
}
