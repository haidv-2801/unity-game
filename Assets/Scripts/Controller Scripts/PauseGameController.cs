using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameController : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject gameoverUI;
    public GameObject victoryUI;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                Remuse();
            }
            else
            {
                Pause();
            }
        }
    }

    public void MenuLevel()
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelMenu");
    }

    public void Remuse()
    {

        pauseMenuUI.SetActive(false);
        GameIsPause = false;
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        GameIsPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPause = true;
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleVictoryUI()
    {
        if (victoryUI.active == true)
        {
            victoryUI.SetActive(false);
            GameIsPause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
        else
        {
            victoryUI.SetActive(true);
            GameIsPause = true;
            Time.timeScale = 0f;
        }    
    }

    public void ToggleGameoverUI()
    {
        if (gameoverUI.active == true)
        {
            GameIsPause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameoverUI.SetActive(false);
        }    
        else
        {
            GameIsPause = true;
            Time.timeScale = 0f;
            gameoverUI.SetActive(true);
        }    
    }
}
