using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField]
    CandleHit listCandle;

    [SerializeField]
    GameObject candleFlame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleCandle()
    {
        if(candleFlame.activeSelf == false)
        {
            listCandle.newCandleDiscover();
        }
    }
}
