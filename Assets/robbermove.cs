using UnityEngine;
using UnityEngine.InputSystem;

public class robbermove : MonoBehaviour
{
   
    private float jumpPower = 5f;
    float movementX; 

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
}
