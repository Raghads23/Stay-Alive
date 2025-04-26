using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    float wait;
    public GameObject dropDestroy;

    void Start()
    {
        InvokeRepeating("Fall", Random.Range(0.5f, 1f),Random.Range(0.5f, 1f));
    }


    void Fall()
    {
       GameObject drop = Instantiate(dropDestroy, new Vector3(Random.Range(-3,4),5,0),Quaternion.identity);
   
         // تعديل الحجم بشكل عشوائي (بين 0.5 و 1.5 مثلاً)
        float randomScale = Random.Range(0.5f, 1.5f);
        drop.transform.localScale = new Vector3(randomScale, randomScale, 1f);

        
         Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();   
   
         float randomFallSpeed = Random.Range(-3f, 7f); // نزول بسرعات مختلفة
         rb.linearVelocity = new Vector2(0, randomFallSpeed);
    }
}
