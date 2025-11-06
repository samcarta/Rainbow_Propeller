using UnityEngine;
using UnityEngine.InputSystem;

public class robbermove : MonoBehaviour
{
   
    [SerializeField] float jumpPower = 10f;
    private float movementX;
    private bool isGrounded;
    private bool isJumping;
    private bool hasDoubleJumped;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float speed = 7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocityX = movementX * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
    }

    void OnJump(InputValue value)
    {
        if((isGrounded && !isJumping) || !hasDoubleJumped)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            isGrounded = false;
            if(!isJumping)
            {
                isJumping = true;
            }
            else
            {
                hasDoubleJumped = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            hasDoubleJumped = false;
        }
    }
}