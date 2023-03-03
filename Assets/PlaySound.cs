using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioClip[] sounds;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound() {
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.PlayOneShot(source.clip);
    }
}
