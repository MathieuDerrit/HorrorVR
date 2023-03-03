using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int pentagrams = 0;
    [SerializeField] int currentHP = 3;
    [SerializeField] int maxHP = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damages)
    {
        currentHP -= damages;
        if (currentHP <= 0) {
            Debug.Log("LOSE");
        }
    }
    public void addPentagrmme()
    {
        pentagrams =+ 1;
    }
}
