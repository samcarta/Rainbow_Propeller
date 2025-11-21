using UnityEngine;

public class Ladder2D : MonoBehaviour
{
    public float climbSpeed = 5f;

    private bool isClimbing = false;
    private Rigidbody2D playerRb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody2D>();
            isClimbing = true;
            playerRb.gravityScale = 0f; // turned off gravity
            playerRb.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;
            playerRb.gravityScale = 1f; 
            playerRb = null;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing && playerRb != null)
        {
            float vertical = Input.GetAxis("Vertical"); 
            playerRb.linearVelocity = new Vector2(
                playerRb.linearVelocity.x,
                vertical * climbSpeed
            );
        }
    }
}
