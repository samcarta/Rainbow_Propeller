using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeScreenManager : MonoBehaviour
{
    [SerializeField] GameObject escapeMenu;

    public void Home()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
