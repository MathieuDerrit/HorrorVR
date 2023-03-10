using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pentacle : MonoBehaviour
{
    [SerializeField] InputActionProperty action;
    [SerializeField] GameObject XROrigin;
    [SerializeField] Transform Boss;
    [SerializeField] Transform BossAttach;
    bool isArea = false;
    bool isRelease = false;
    [SerializeField] int pentagramsNeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (action.action.WasPressedThisFrame() && isArea && isRelease == false)
        {
            Debug.Log(XROrigin.GetComponent<Player>().pentagrams);
            if (XROrigin.GetComponent<Player>().pentagrams == pentagramsNeed) {
                Debug.Log("INVOCATION");
                Instantiate(Boss, BossAttach);
                isRelease = true;

                if (GetComponent<PlaySound>() != null) {
                    GetComponent<PlaySound>().playSound();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isArea = true;
    }

}
