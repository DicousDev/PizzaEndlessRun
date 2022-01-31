using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner.Utils
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private CanvasGroup loading;
        [Range(0.1f, 1)]
        [SerializeField] private float fadeTime = 0.5f;

        public IEnumerator FadeIn()
        {
            float start = 0;
            float end = 1;
            float speed = (end - start) / fadeTime;
            
            loading.alpha = start;
            while(loading.alpha < end)
            {
                loading.alpha += speed * Time.unscaledDeltaTime;
                yield return null;
            }

            loading.alpha = end;
        }

        public IEnumerator FadeOut()
        {
            float start = 1;
            float end = 0;
            float speed = (end - start) / fadeTime;
            
            loading.alpha = start;
            while(loading.alpha > end)
            {
                loading.alpha += speed * Time.unscaledDeltaTime;
                yield return null;
            }

            loading.alpha = end;
        }
    }
}