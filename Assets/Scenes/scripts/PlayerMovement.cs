using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    private Rigidbody2D player;
    private float moveInput;
    public bool canMove = true; // نتحكم في الحركة من سكربت آخر
    public float smooth = 0.1f; // للتحكم في انسيابية الحركة
     private float velocityX;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
        if (canMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            velocityX = math.lerp(player.linearVelocity.x,moveInput * speed,smooth);
            player.linearVelocity = new Vector2(velocityX, player.linearVelocity.y); 
        }
    }

}
