using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class HandSelected : MonoBehaviour
{

    private bool _isGraped = false;

    [SerializeField]
    private InputActionProperty _GripLeftBtn;
    [SerializeField]
    private InputActionProperty _GripRightBtn;

    void Update()
    {
        if (_isGraped)
        {
            if (_GripRightBtn.action.ReadValue<float>() > 0.1)
            {
                OnRightHandGrap();
            }
            else if (_GripLeftBtn.action.ReadValue<float>() > 0.1)
            {
                OnLeftHandGrap();
            }
        }

        UpdateChild();
    }

    protected virtual void OnLeftHandGrap()
    {

    }

    protected virtual void OnRightHandGrap()
    {

    }

    protected virtual void UpdateChild()
    {

    }

    public void SetIsGrapped(bool graped)
    {
        _isGraped = graped;
    }
}