using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class FinalEnemy : MonoBehaviour
{
    [SerializeField] GameObject sightline2;
    [SerializeField] GameObject enemy2;
    [SerializeField] Rigidbody2D enemyRB2;
    bool facingLeft;
    private float timer;
    private float flipTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Time.time;
        facingLeft = true;
        enemyRB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Time.time - timer >= flipTime)
        {
            enemy2.transform.Rotate(0f, 180f, 0f);
            sightline2.transform.Rotate(0f, 180f, 0f);
            timer = Time.time;
            if (facingLeft)
            {
                facingLeft = false;
            }
            else
            {
                facingLeft = true;
            }
        }
    }
}
