using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankToDestroy : MonoBehaviour
{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
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
        Debug.Log(collision.collider.name);
        if(collision.gameObject.tag == "Weapon")
        {
            Door1.GetComponent<Rigidbody>().freezeRotation = false;
            Door2.GetComponent<Rigidbody>().freezeRotation = false;
            Destroy(gameObject);
        }
    }
}
