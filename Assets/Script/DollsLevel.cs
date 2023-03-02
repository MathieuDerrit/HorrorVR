using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DollsLevel : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField] GameObject Pentacle;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject slot in slots) {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDoll() {
this.checkDolls();
    }
    public void removeDoll(GameObject slot, GameObject doll) {

    }
    void checkDolls() {
        if (slots[0].GetComponent<XRSocketInteractor>().GetOldestInteractableSelected() != null) {
            int num = int.Parse(slots[0].GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.name.Replace("Matreshka.",""));
            int nbGood = 0;
            foreach (GameObject slot in slots) {
                if (slot.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected() != null) {
                    if (num >= int.Parse(slot.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.name.Replace("Matreshka.",""))) {
                        num = int.Parse(slot.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.name.Replace("Matreshka.",""));
                        nbGood++;       
                    }
                } 
            }
            if (nbGood >= slots.Length) {
                Debug.Log("DOLLS SUCCESS");
                if (!GameManager._Instance._dollsSuccess) {
                   GameManager._Instance.IntancePentagram();
                   GameManager._Instance._dollsSuccess = true;
                }
            }
        }
    }
}
