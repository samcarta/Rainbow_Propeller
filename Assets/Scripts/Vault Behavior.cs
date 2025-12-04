using UnityEngine;
using UnityEngine.InputSystem;

public class VaultBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject escapeScreen;
    [SerializeField] GameObject eToLeave;
    [SerializeField] GameObject vault;
    bool canLeave = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (canLeave && vault.activeSelf == true)
        {
            escapeScreen.SetActive(true);
            eToLeave.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
