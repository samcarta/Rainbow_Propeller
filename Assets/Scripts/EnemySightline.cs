using UnityEngine;
using UnityEngine.UIElements;

public class EnemySightline : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject heart1;
    [SerializeField] public GameObject heart2;
    [SerializeField] public GameObject heart3;
    [SerializeField] public GameObject DeathScreen;
    private bool heart_1 = true;
    private bool heart_2 = true;
    private bool heart_3 = true;   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        DeathScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Player"))
        {
            if(heart_3)
            {
                heart3.SetActive(false);
                heart_3 = false;
            }
            else if(heart_2)
            {
                heart2.SetActive(false);
                heart_2 = false;
            }
            else if(heart_1)
            {
                heart1.SetActive(false);
                heart_1 = false;
                Die();
            }
        }
    }
}
