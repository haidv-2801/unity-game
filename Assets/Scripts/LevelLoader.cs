using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int iLevelToload;
    public string sLevelToload;

    public bool useIntegerToloadLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisipnGameObject = collision.gameObject;
        if (collisipnGameObject.name == "Player")
        {
            Debug.Log("scene passing");
            GetComponent<PauseGameController>().ToggleVictoryUI();
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (useIntegerToloadLevel)
        {
            SceneManager.LoadScene(iLevelToload);
        }
        else
        {
            SceneManager.LoadScene(sLevelToload);
        }
    }
}
