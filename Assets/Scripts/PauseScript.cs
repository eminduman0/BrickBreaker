using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.PlayMusic(AudioManager.instance.mainMenuMusic);
    }
}
