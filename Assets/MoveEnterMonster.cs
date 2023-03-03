using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnterMonster : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition){
            Destroy(gameObject);
        }
    }
}
