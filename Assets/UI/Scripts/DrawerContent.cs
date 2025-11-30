using UnityEngine;

public class DrawerContent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onClick()
    {
        print("Picked up drawer content");
        Object.Destroy(this.gameObject);
    }
}
