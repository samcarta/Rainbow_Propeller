using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject sightline;
    [SerializeField] GameObject enemy;
    [SerializeField] float flipTime = 5f;
    [SerializeField] float firstPauseTime = 1.5f;
    [SerializeField] float secondPauseTime = 1.5f;
    [SerializeField] float moveTime = 2f;
    private float timer;
    [SerializeField] Rigidbody2D enemyRB;
    private bool facingLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Time.time;
        facingLeft = true;
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Time.time - timer >= flipTime)
        {
            enemy.transform.Rotate(0f, 180f, 0f);
            sightline.transform.Rotate(0f, 180f, 0f);
            timer = Time.time;
            if (facingLeft)
            {
                facingLeft = false;
            }
            else
            {
                facingLeft = true;
            }
            EnemyMove();
        }
    }

    IEnumerator EnemyMove()
    {
        yield return new WaitForSeconds(firstPauseTime);
        if (facingLeft)
        {
            enemyRB.linearVelocityX = 10f;
        }
        else
        {
            enemyRB.linearVelocityX = -10f;
        }
        yield return new WaitForSeconds(moveTime);
        enemyRB.linearVelocityX = 0f;
        yield return new WaitForSeconds(secondPauseTime);
    }
}

