using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep;
    [SerializeField] InputActionProperty action;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (action.action.WasPressedThisFrame())
        {
            footsteps();
        } else {
            StopFootsteps();
        }
*/
Debug.Log("tt");
        if(Input.GetKey("w"))
        {
            footsteps();
        }
        if(Input.GetKeyUp("w"))
        {
            StopFootsteps();
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
}