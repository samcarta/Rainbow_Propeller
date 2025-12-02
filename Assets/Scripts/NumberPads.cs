using Unity.Cinemachine;
using UnityEngine;


public class NumberPads : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject numberPad1; 
    [SerializeField] GameObject EtoOpen;
    bool canopen =(false);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            EtoOpen.SetActive(true);
            canopen = true;  
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            EtoOpen.SetActive(false);
                canopen = false;
        }
           
    } 
    public void OnInteract()
    {
        if (canopen)
        {
            numberPad1.SetActive(true);
        }
    }
}
