using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update


    public Image ImageColor;
    public float fadeSpeed;
    private bool startFade = false;

    void Start()
    {
        //objectToFadeColor = objectColor.GetComponent<Image>();
        StopAllCoroutines();
        StartCoroutine(WaitFade());
    }

    // Update is called once per frame
    void Update()
    {
        print(ImageColor.color.a);
        if (startFade)
        {
            if (ImageColor.color.a > 0.01)
            {
                ImageColor.color = new Color(ImageColor.color.r, ImageColor.color.g, ImageColor.color.b, Mathf.Lerp(ImageColor.color.a, 0, 0.001f));
            }
            else
            {
                ImageColor.color = new Color(ImageColor.color.r, ImageColor.color.g, ImageColor.color.b, 0f);
            }
        }
       
    }

    public IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(8);
        startFade = true;
    }

}
