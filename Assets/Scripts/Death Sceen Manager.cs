using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceenManager : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;

    public void Home()
    {
        SceneManager.LoadScene("Title screen 1");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
