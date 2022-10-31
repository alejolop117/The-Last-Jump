using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
