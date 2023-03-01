using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFeatures : MonoBehaviour
{
    public void GrabBegin () {
        Debug.Log("GRAAB");
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if (gameObject.GetComponent<Item>() == null) return;
        if (gameObject.GetComponent<Item>().inSlot) 
        {
            gameObject.transform.parent = null;
            gameObject.GetComponent<Item>().inSlot = false;
            gameObject.GetComponent<Item>().currentSlot.ResetColor();
            gameObject.GetComponent<Item>().currentSlot.ItemInSlot = null;
        }
    }

    virtual public void GrabEnd () {
        //gameObject.GetComponent<Rigidbody>.isKinematic = false;
    }
}
