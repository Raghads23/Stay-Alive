using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFade : MonoBehaviour
{
    public Light2D light2D;
    public float fadeTime = 1f;

    public void FadeOut()
    {
        StartCoroutine(FadeLight());
    }

    System.Collections.IEnumerator FadeLight() // ينفذه تدريجيا
    {
        float startIntensity = light2D.intensity;
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            light2D.intensity = Mathf.Lerp(startIntensity, 0f, t / fadeTime); //  النسبة التي تحدد تقدم التلاشي بمرور الوقت. إذا كانت النسبة 0، يعني التلاشي لم يبدأ بعد. إذا كانت 1، يعني التلاشي اكتمل.
            yield return null;
        }

        light2D.intensity = 0f;
    }
}
