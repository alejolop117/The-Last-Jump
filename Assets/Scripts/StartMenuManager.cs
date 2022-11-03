using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject instructionsScreen, mainMenuScreen;
    public void StartGame() {
        SceneManager.LoadScene("LevelOne");
    }

    public void Instructions() {
        instructionsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }

    public void OK() {
        instructionsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
