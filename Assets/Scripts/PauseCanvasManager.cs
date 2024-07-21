using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel,bgPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGameButton();
        }
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        bgPanel.SetActive(false);
    }

    public void PauseGameButton()
    {
        pausePanel.SetActive(true);
        bgPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGameButton()
    {
        pausePanel.SetActive(false);
        bgPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGameButton()
    {
        pausePanel.SetActive(false);
        bgPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnMenuButton()
    {  
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
