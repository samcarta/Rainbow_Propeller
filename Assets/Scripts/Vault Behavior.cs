using UnityEngine;

public class VaultBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject escapeScreen;

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
            escapeScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
