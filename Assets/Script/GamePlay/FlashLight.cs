using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    public InputActionProperty _Xbtn;

    public Light _SpotLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Xbtn.action.WasPressedThisFrame())
        {
            if (!_SpotLight.enabled)
            {
                _SpotLight.enabled = true;
            }
            else
            {
                _SpotLight.enabled = false; 
            }
        }
        
    }
}
