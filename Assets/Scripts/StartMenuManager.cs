using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject instructionsScreen, mainMenuScreen;
    [SerializeField] GameObject[] planets;
    public void StartGame() {
        SceneManager.LoadScene("LevelOne");
    }

    public void Instructions() {
        instructionsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
        for (ushort i = 0; i < planets.Length; i++) 
            planets[i].SetActive(false);
    }

    public void OK() {
        instructionsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        for (ushort i = 0; i < planets.Length; i++) 
            planets[i].SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
