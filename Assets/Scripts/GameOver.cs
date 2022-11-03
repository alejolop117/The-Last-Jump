using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Impulse playerMovement;

    public void Game_Over() {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        playerMovement.enabled = false;
    }
}
