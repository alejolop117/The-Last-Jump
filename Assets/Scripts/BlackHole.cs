using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] GameOver gameOverScreen;
    [SerializeField] float timeToLose = 6.5f;
    public void IsInABlackHole() {
        StartCoroutine(nameof(GarguantuaPirat));
    }

    IEnumerator GarguantuaPirat() {
        yield return new WaitForSeconds(timeToLose);
        gameOverScreen.Game_Over();
    }
}
