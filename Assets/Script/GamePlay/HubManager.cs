using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour
{
    public enum HubState
    {
        Choosing,
        Start,
        Setting,
        Quit
    }

    public HubState CurrentState;

    private void Awake()
    {
        CurrentState = HubState.Choosing;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
