using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer;
    public int coins;
    public Text coinText;
    public Text highScoreVictory;
    public Text highScoreDefeat;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        gamePlayer = FindObjectOfType<PlayerController>();
        coinText.text = "Score:" + coins;
        highScoreVictory.text = "High Score:" + coins;
        highScoreDefeat.text = "High Score:" + coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.playerAnimation.SetBool("collidedEnemies", true);
        yield return new WaitForSeconds(respawnDelay); // delay
        
        gamePlayer.gameObject.SetActive(false);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
        playerHealth.CurrentHealth = 10;
    }

    public void AddCoins(int numberOfCoins) 
    {
        coins += numberOfCoins;
        coinText.text = "Score:" + coins;
        highScoreVictory.text = "High Score:" + coins;
        highScoreDefeat.text = "High Score:" + coins;
    }
}
