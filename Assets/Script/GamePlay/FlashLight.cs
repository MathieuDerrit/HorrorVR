using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class FlashLight : HandSelected
{
    [SerializeField]
    private InputActionProperty _PrimaryLeftBtn;
    [SerializeField]
    private InputActionProperty _PrimaryRightBtn;

    [SerializeField]
    private Light _SpotLight;

    protected override void OnLeftHandGrap()
    {
        if (_PrimaryLeftBtn.action.WasPressedThisFrame())
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

    protected override void OnRightHandGrap()
    {
        if (_PrimaryRightBtn.action.WasPressedThisFrame())
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