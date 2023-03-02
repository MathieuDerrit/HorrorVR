using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectChestKey : MonoBehaviour
{
    public Outline _Outline;
    public static GameObject _Key;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ChestKey")
        {
            _Key = other.gameObject;
            other.gameObject.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ChestKey")
        {
            other.gameObject.GetComponent<Outline>().enabled = false;
        }
    }

    public void DisableOutline()
    {
        if (_Outline != null)
        {
            _Outline.enabled = false;
        }
    }
}
