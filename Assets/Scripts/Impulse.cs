using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour {
    [SerializeField] float speed;
    Vector3 velocity;
    Vector3 acceleration;
    LookAt m_lookAt;
    PlanetDetector gravitationalZone;
    bool impulse = false;
    
    ushort initControl = 0;

    private void Awake() {
        m_lookAt = GetComponent<LookAt>();
        gravitationalZone = GetComponent<PlanetDetector>();
    }

    void Update() {

        Init();

        if (impulse) {
            
            UpdateMovementVector();
            if (gravitationalZone.planet1 != null) {
                acceleration = gravitationalZone.planet1.transform.position - transform.position;
                acceleration.Normalize();
                acceleration *= gravitationalZone.planet1.acceleration;
            }

            velocity += acceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
            RotateZ(Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2f);
        }
    }

    private void UpdateMovementVector() {

        //velocity = target - transform.position;
        velocity.Normalize();
        velocity *= speed;
        acceleration *= 0;
        velocity.z = 0;
    }

    private Vector3 GetWorldMousePosition() {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float radians) {

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

    private void Init() {
 
        if (Input.GetMouseButtonDown(0) && initControl == 0) {
            velocity = GetWorldMousePosition() - transform.position;
            
            m_lookAt.enabled = !m_lookAt.enabled;
            impulse = true;
            initControl++;
        }
    }
}
