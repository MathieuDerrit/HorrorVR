using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ChruchQuest : MonoBehaviour
{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    public static ChruchQuest _Instance;
    public int NbMonstersKilled = 0;
    [SerializeField]  public int NbMonstersToKill;
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
        Debug.Log(collision.gameObject.name);
    }

    public void AddMonsterKilled()
    {
        NbMonstersKilled += 1;
        if(NbMonstersKilled >= NbMonstersToKill)
        {
            Door1.GetComponent<Rigidbody>().freezeRotation = false;
            Door2.GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
