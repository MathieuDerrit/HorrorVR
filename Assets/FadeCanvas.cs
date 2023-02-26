using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    // Start is called before the first frame update

    public Image FadeImage;
    public float Duration;
    void Start()
    {
        //print((float)1/50); 
        StartCoroutine(Fade(Duration));
    }

    private IEnumerator Fade(float Time)
    {
        float nbrOfTime = Time / 0.1f;
        float fadeSubstract = 1.0f / nbrOfTime;
        for (int i = 0; i < nbrOfTime; i++)
        {
            yield return new WaitForSeconds(0.1f);
            float alpha = FadeImage.color.a - fadeSubstract;
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);
        }
    }
}
