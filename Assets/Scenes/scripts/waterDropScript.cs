using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public GameObject dropDestroy;

    void Start()
    {
        StartCoroutine(SpawnDrops()); // تتحكم بالتوقيت Coroutine
    }

    
    IEnumerator SpawnDrops() //دالة تقدر توقف مؤقتًا وتكمل بعدين.
    {
    
        while (true)
        {
            Fall(); // تنشئ القطرة

            float waitTime = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(waitTime); // تتوقف مؤقتًا بدون ما توقف البرنامج كله،وترجع تكمل بعد مدة(yield return) 

        }

    }


    void Fall()
    {
       GameObject drop = Instantiate(dropDestroy, new Vector3(Random.Range(-3,4),5,0),Quaternion.identity);// بدون دوران (Quaternion.identity = دوران 0).
   
         // تعديل الحجم بشكل عشوائي (بين 0.5 و 1.5 مثلاً)
        float randomScale = Random.Range(0.5f, 1.5f);
        drop.transform.localScale = new Vector3(randomScale, randomScale, 1f);

        
         Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();   
   
         float randomFallSpeed = Random.Range(-3f, -7f); // نزول بسرعات مختلفة
         rb.linearVelocity = new Vector2(0, randomFallSpeed); // 0 -> fixed in x

    }
}
