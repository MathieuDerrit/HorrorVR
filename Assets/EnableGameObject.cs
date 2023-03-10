using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObject : MonoBehaviour
{
    public GameObject gameObject;

    public AudioClip audioClip;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;

        int LayerPlayer = LayerMask.NameToLayer("Player");

        if (obj.layer == LayerPlayer) {
            gameObject.SetActive(true);
            audioSource.clip = audioClip;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
