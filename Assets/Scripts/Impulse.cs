using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour {
    [SerializeField] float speed = 5f;
    [SerializeField] float downSpeed = 1.5f;
    Vector3 velocity;
    Vector3 acceleration;
    LookAt m_lookAt;
    PlanetDetector gravitationalZone;
    bool impulse = false;
    public ushort initControl = 0;
    Vector3 position = new Vector3();
    float timer = 0f;

    private void Awake() {
        m_lookAt = GetComponent<LookAt>();
        gravitationalZone = GetComponent<PlanetDetector>();
    }

    private void Start() {
        position = transform.position;
        position.z = -1;
    }

    void Update() {

        Init();

        if (impulse) {
            
            UpdateMovementVector();
            if (gravitationalZone.planet1 != null && !gravitationalZone.arrived) {
                acceleration = gravitationalZone.planet1.transform.position - transform.position;
                acceleration.Normalize();
                acceleration *= gravitationalZone.planet1.acceleration;
            }

            velocity += acceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
            RotateZ(Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2f);
        }
    }

    /*private void FixedUpdate() {
        if (transform.position.z != -1) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }*/

    private void UpdateMovementVector() {

        //if (gravitationalZone.arrived) velocity = gravitationalZone.planet1.transform.position - transform.position;
        //velocity = target - transform.position;
        if (gravitationalZone.arrived) {
            //velocity -= velocity.normalized * downSpeed;
            if (timer <= downSpeed) {
                timer += Time.deltaTime;
                speed = downSpeed - timer;
            }
            else speed = 0;
            
        }
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
