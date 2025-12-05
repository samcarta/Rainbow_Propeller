using UnityEngine;
using UnityEngine.InputSystem;

public class robbermove : MonoBehaviour
{
   
    [SerializeField] float jumpPower = 10f;
    private float movementX;
    private bool isGrounded;
    private bool isJumping;
    private bool hasDoubleJumped;
    private bool isCrouching;
    private bool facingRight;
    [SerializeField] GameObject robber;
    [SerializeField] Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float speed = 7f;

    [SerializeField] GameObject numberPad1;
    [SerializeField] GameObject EtoOpen;
    bool canopen = false;
    [SerializeField] GameObject escapeScreen;
    [SerializeField] GameObject eToLeave;
    [SerializeField] GameObject vault;
    bool canLeave = false;
    [SerializeField] GameObject eToWin;
    [SerializeField] GameObject winScreen;
    bool canWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCrouching = false;
        isJumping = false;
        hasDoubleJumped = false;
        facingRight = true;
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

        if (v.x > 0 && !facingRight)
        {
            robber.transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }
        else if(v.x < 0 && facingRight)
        {
            robber.transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        }

        animator.SetBool("walking", v.x != 0);

        movementX = v.x;
    }

    void OnJump(InputValue value)
    {
        if((isGrounded && !isJumping) || !hasDoubleJumped)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("jumping", true);
            if (!isJumping)
            {
                isJumping = true;
            }
            else
            {
                hasDoubleJumped = true;
            }
        }
    }

    void OnCrouch(InputValue value)
    {
        if(!isCrouching)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            speed = speed / 2;
            isJumping = true;
            hasDoubleJumped = true;
            isCrouching = true;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            speed = speed * 2;
            isJumping = false;
            hasDoubleJumped = false;
            isCrouching = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Ground") && !isCrouching)
        {
            isGrounded = true;
            isJumping = false;
            hasDoubleJumped = false;
            animator.SetBool("jumping", false);
        }
        if(other.CompareTag("Boss"))
        {
            eToWin.SetActive(true);
            canWin = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Boss"))
        {
            eToWin.SetActive(false);
            canWin = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("NumberPad"))
        {
            EtoOpen.SetActive(true);
            canopen = true;
        }
        if (other.CompareTag("Vault"))
        {
            eToLeave.SetActive(true);
            canLeave = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("NumberPad"))
        {
            EtoOpen.SetActive(false);
            canopen = false;
        }
        if (other.CompareTag("Vault"))
        {
            eToLeave.SetActive(false);
            canLeave = false;
        }
    }

    void OnInteract(InputValue value)
    {
        if (canopen)
        {
            numberPad1.SetActive(true);
        }
        if (canLeave && vault.activeSelf == true)
        {
            escapeScreen.SetActive(true);
            eToLeave.SetActive(false);
            Time.timeScale = 0f;
        }
        if (canWin)
        {
            winScreen.SetActive(true);
            eToWin.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
