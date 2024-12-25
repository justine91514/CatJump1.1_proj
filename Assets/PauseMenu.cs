using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; 

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        Debug.Log("Home button clicked!");
        Time.timeScale = 1; // Reset time scale when going to another scene
        SceneManager.LoadScene("Lobby");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Debug.Log("Restart button clicked!");
        Time.timeScale = 1; // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
