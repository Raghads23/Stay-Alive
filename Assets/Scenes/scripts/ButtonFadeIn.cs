using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonFadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2f;

    void Start()
    {
        canvasGroup.alpha = 0f; // بالبداية يكون مخفي
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration); // عشان نضمن انه بين ٠ و ١ Clamp01
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f; // نتأكد أنه صار ظاهر تماماً
    }
}