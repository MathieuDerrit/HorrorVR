using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnterMonster : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
