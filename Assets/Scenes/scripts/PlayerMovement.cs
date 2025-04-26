using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public int speed;
    private float moveInput;
    public bool canMove = true; // نتحكم في الحركة من سكربت آخر
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
            velocityX = math.lerp(player.linearVelocity.x, moveInput * speed, 0.1f); //من اي الى بي بمقدار 0.1 
            player.linearVelocity = new Vector2(velocityX, player.linearVelocity.y); 
        }
    }

}
