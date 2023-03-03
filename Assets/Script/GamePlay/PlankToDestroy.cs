using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankToDestroy : MonoBehaviour
{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] public bool activated = false;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "crowBar")
        {
            Door1.GetComponent<Rigidbody>().freezeRotation = false;
            Door2.GetComponent<Rigidbody>().freezeRotation = false;
            activated = true;
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
            Destroy(gameObject);
        }
    }
}
