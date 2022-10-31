using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Impulse playerImpulse;
    [SerializeField] LookAt playerLook;
    static bool gameIsPaused = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) Resume();
            else Pause();
        }
    }
    void Pause() {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameIsPaused = true;
        playerImpulse.enabled = false;
        playerLook.enabled = false;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        playerImpulse.enabled = true;
        if(playerImpulse.initControl == 0) playerLook.enabled = true;
    }
    public void QuitGame() {
        Application.Quit();
    }
}
