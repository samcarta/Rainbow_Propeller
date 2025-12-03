using UnityEngine;
using UnityEngine.UI;

public class DrawerContent : MonoBehaviour
{
    public Button button;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(RemoveObjectFromDrawer);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(RemoveObjectFromDrawer);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RemoveObjectFromDrawer()
    {
        print("Picked up drawer content");
        this.gameObject.SetActive(false);
    }
}
