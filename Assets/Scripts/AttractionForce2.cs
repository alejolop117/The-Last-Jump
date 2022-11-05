using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionForce2 : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public float mass = 1f;
    public Vector2 position;

    private void Start() {
        position = new Vector2(transform.position.x, transform.position.y);
    }
}
