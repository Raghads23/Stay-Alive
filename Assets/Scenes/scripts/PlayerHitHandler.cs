using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerHitHandler : MonoBehaviour
{
    private PlayerMovement player; // PlayerMovement script

    private Animator animator;
    private string hitAnimationName = "hitAnimation"; // hit animation name
    //private bool isHit = false; 

    public LightFade light; // LightFade script
    public ParticleSystem splashEffect; // Particle System
    public AudioClip waterTouchFire; // Audio 
    public string sceneName;


    void Start()
    {

        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision) // اذا القيم اوبجكت اللي فيه السكربت تصادم بشي ثاني
    {
        if (collision.gameObject.CompareTag("drops")) //  && !isHit
        {
            //isHit = true;
            player.canMove = false; // in PlayerMovement script
            animator.SetTrigger("hit");
            AudioSource.PlayClipAtPoint(waterTouchFire,Vector3.zero);


             if (light != null) 
             {
                light.FadeOut();
                splashEffect.Stop();
             }
             
            StartCoroutine(WaitForAnimation("hitAnimation"));

        }
       
       
    }

    System.Collections.IEnumerator WaitForAnimation(string animationName)
    {
        // ننتظر لين يبدأ الأنميشن
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null; // if true
        }
            
        // ننتظر لين ينتهي الأنميشن
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) // normalizedTime = النسبة المئوية من الأنيميشن الذي تم تنفيذه
        {
            yield return null; // if true
        }
            

        // تحميل المشهد الذي كتبته في الـ Inspector
        SceneManager.LoadScene(sceneName);
    }
}
