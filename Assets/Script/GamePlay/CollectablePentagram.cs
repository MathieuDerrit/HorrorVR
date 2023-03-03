using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollectablePentagram : MonoBehaviour
{
    [SerializeField] InputActionProperty action;
    bool isArea = false;
    GameObject XROrigin;
    GameObject Player;
    // Start is called before the first frame update
    void Start()    
    {
        Player = GameObject.Find("Main Camera");
        XROrigin = GameObject.Find("XR Origin");
        transform.SetParent(Player.transform);
        transform.SetLocalPositionAndRotation(new Vector3(0,0,0.50f), new Quaternion(0,180,0,0));
        GameManager._Instance.EnableUICollectPentagram();
    }

    // Update is called once per frame
    void Update()
    {
        if (action.action.WasPressedThisFrame() && isArea)
        {
            GameManager._Instance.DisableUICollectPentagram();
            XROrigin.GetComponent<Player>().pentagrams++;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isArea = true;
        Debug.Log("ENTER");
    }
}
