using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollectablePentagram : MonoBehaviour
{
    [SerializeField] InputActionProperty action;
    bool isArea = false;
    GameObject colliderObj;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera");
        transform.SetParent(player.transform);
        transform.SetLocalPositionAndRotation(new Vector3(0,0,0.25f), new Quaternion(0,180,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        if (action.action.WasPressedThisFrame() && isArea)
        {
            if (colliderObj.GetComponent<Player>())
                colliderObj.GetComponent<Player>().pentagrams++;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isArea = true;
        colliderObj = other.gameObject;
        Debug.Log("ENTER");
    }

    private void OnTriggerExit(Collider other)
    {
        isArea = false;
    }
}
