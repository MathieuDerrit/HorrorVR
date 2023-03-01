using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class InventoryVR : MonoBehaviour
{

    [SerializeField] InputActionReference _input;


    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;

    public XRController rightHand;
    public InputHelpers.Button button;




    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;

        _input.action.started += OnFireInput;
    }

    private void OnFireInput(InputAction.CallbackContext obj) {
 Debug.Log("Pressed !!! ");
    }

    private void Update()
    {  Debug.Log("U ");
        /*
        bool pressed;
        
        rightHand.inputDevice.IsPressed(button, out pressed);


 
        if (pressed) {*/
        if (_input.action.IsPressed()) {
            Debug.Log("Pressed - " + button);

            UIActive = !UIActive;
            Inventory.SetActive(UIActive);
        }
        
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
        
    }
}