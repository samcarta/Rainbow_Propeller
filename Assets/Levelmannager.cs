using UnityEngine;
using UnityEngine.SceneManagement;


public class Levelmannager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel1() {
        SceneManager.LoadScene("Bank");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2 Bank");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Bank");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
}
