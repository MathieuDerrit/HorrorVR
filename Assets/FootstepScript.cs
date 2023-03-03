using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootstepScript : MonoBehaviour
{
    [SerializeField] InputActionProperty action;
    public AudioClip[] sounds;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (action.action.WasPressedThisFrame() && !source.isPlaying)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
        }

        if(Input.GetKey("w"))
        {
                        source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
        }
    }
}