using UnityEngine;
using UnityEngine.SceneManagement;


public class Levelmannager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject options;
    [SerializeField] GameObject mainmenu;
    [SerializeField] GameObject title;
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

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        options.SetActive(true);
        mainmenu.SetActive(false);
        title.SetActive(false);
    }
}
