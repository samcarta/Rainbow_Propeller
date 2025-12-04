using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class FinalEnemy : MonoBehaviour
{
    [SerializeField] GameObject sightline2;
    [SerializeField] GameObject enemy2;
    [SerializeField] Rigidbody2D enemyRB2;
    bool canLeave = false;
    [SerializeField] GameObject eToLeave;
    [SerializeField] GameObject escapeScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        enemy2.transform.Rotate(0f, 0f, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            eToLeave.SetActive(true);
            canLeave = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            eToLeave.SetActive(false);
            canLeave = false;
        }
    }

    void OnInteract(InputValue value)
    {
        if (canLeave)
        {
            escapeScreen.SetActive(true);
            eToLeave.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
