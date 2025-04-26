using UnityEngine;

public class dropDestroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }



}
