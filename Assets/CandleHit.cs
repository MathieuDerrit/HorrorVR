using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CandleHit : MonoBehaviour
{
    public List<GameObject> listCandle = new List<GameObject>();

    public float nbCandleDiscover;

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
        nbCandleDiscover = nbCandleDiscover + 1;
        Text.SetText(nbCandleDiscover + " / " + listCandle.Count);
        canvas.SetActive(true);
        StartCoroutine(DisableUI());

        if (nbCandleDiscover == listCandle.Count)
        {
            if (!GameManager._Instance._candleSuccess)
            {
                GameManager._Instance.InstancePentagram();
                GameManager._Instance._candleSuccess = true;
            }
        }
    }

    IEnumerator DisableUI()
    {
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
    }
}
