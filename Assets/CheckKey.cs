using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckKey : MonoBehaviour
{
    [SerializeField] Animation anim;
    [SerializeField] XRSocketInteractor m_Socket;
    bool isRealized = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keyEnter() {
        if (m_Socket.GetOldestInteractableSelected().transform.name == "Key" && !isRealized) {
            anim.Play("ChestAnim");
            isRealized = true;
            //m_Socket.socketActive = false;
            
        }
    }

    void OnCompleteChestAnimation()
    {
        if(!anim.isPlaying) {return;}
    }
}
