using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    public InputActionProperty _Xbtn;

    public Light _SpotLight;

    private bool _isLit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Xbtn.action.WasPressedThisFrame())
        {
            print("BOUTON");
            if (!_isLit)
            {
                _SpotLight.enabled = true;
            }else if (_isLit)
            {
                _SpotLight.enabled = false; 
            }
        }
        
    }
}
