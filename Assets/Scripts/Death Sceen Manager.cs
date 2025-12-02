using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceenManager : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;

    public void Home()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void Restart()
    {
        Debug.Log("working");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
