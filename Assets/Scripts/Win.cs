using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] Impulse playerImpulse;
    [SerializeField] float timeToStartScreen = 3.5f;

    public void HeIsAWinner() {
        StartCoroutine(nameof(WeAreTheChampions));
    }

    IEnumerator WeAreTheChampions() {
        yield return new WaitForSeconds(timeToStartScreen);
        winScreen.SetActive(true);
        Time.timeScale = 0f;
        playerImpulse.enabled = false;
    }
}
