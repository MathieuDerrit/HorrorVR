using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CandleHit : MonoBehaviour
{
    public List<GameObject> listCandle = new List<GameObject>();

    public float nbCandle;

    public float candleDiscover;

    public GameObject canvas;

    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Candle")
            {
                listCandle.Add(child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newCandleDiscover()
    {
        candleDiscover = candleDiscover + 1;
        Text.SetText(candleDiscover + " / " + listCandle.Count);
        canvas.SetActive(true);
    }
}
