using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDetector : MonoBehaviour
{
    public Planet1 planet1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Planet")) {
            planet1 = collision.GetComponent<Planet1>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Planet")) {
            planet1 = null;
        }
    }
}
