using Complete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Script.Manager.MainMenu.States
{
    public class Play : BaseState
    {
        public override void Enter()
        {
            //Elève l'hud et l'interfacee
        }

        public IEnumerator FadeAll(TextMeshProUGUI fadeText, float Time)
        {
            Debug.Log("FADE!!!!!!!");
            float nbrOfTime = Time / 0.1f;
            float fadeSubstract = 1.0f / nbrOfTime;
            for (int i = 0; i < nbrOfTime; i++)
            {
                yield return new WaitForSeconds(0.1f);
                float alpha = fadeText.color.a - fadeSubstract;
                fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, alpha);
            }
        }
    }
}