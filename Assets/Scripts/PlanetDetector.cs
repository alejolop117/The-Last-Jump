using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDetector : MonoBehaviour
{
    public Planet1 planet1;
    public bool arrived = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Planet")|| collision.CompareTag("Finish") || collision.CompareTag("BlackHole")) {
            planet1 = collision.GetComponent<Planet1>();
        }

        if (collision.CompareTag("Finish")) arrived = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Planet")) {
            planet1 = null;
        }

        if (collision.CompareTag("BlackHole")) {
            planet1 = collision.GetComponent<Planet1>();
        }
    }
}
