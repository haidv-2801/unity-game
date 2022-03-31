using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("LevelMenu");
    }

    public void LoadLV1()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadLV2()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LoadLV3()
    {
        SceneManager.LoadScene("Level5");
    }
}
