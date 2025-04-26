using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerHitHandler : MonoBehaviour
{
    private PlayerMovement player;
    private Animator animator;
    private string hitAnimationName = "hitAnimation"; // اسم الأنميشن
    private bool isHit = false;
    public string sceneName;

    public LightFade light;

    void Start()
    {

        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("drops") && !isHit)
        {
            isHit = true;
            player.canMove = false;
            animator.SetTrigger("hit");

             if (light != null){
            light.FadeOut();
        }
            StartCoroutine(WaitForAnimation("hitAnimation"));

        }
       
       
    }

    System.Collections.IEnumerator WaitForAnimation(string animationName)
    {
        // ننتظر لين يبدأ الأنميشن
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            yield return null;

        // ننتظر لين ينتهي الأنميشن
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            yield return null;

        // تحميل المشهد الذي كتبته في الـ Inspector
        SceneManager.LoadScene(sceneName);
    }
}
