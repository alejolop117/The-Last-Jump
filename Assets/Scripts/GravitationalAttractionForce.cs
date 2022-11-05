using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalAttractionForce : MonoBehaviour
{
    enum TypeBody { Planet, Sun }
    [Header("Components")]
    [SerializeField] Vector2 acceleration;
    [SerializeField] Vector2 velocity;
    public Vector2 position;
    
    [SerializeField] float mass = 1f;
    [SerializeField] TypeBody typeBody;
    [SerializeField] GravitationalAttractionForce planetTwo;
    [SerializeField] GameObject sun;
    AttractionForce2 sunAttraction;

    void Start() {
        position = new Vector2(transform.position.x, transform.position.y);
        if(typeBody == TypeBody.Sun) {
            sunAttraction = sun.GetComponent<AttractionForce2>();
        }

    }

    private void FixedUpdate() {
        
        acceleration = new Vector2(0, 0); 

        ApplyForce(AttractionForce());

        Move();
    }
    public void Move() {

        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (velocity.magnitude >= 10f) {
            velocity.Normalize();
            velocity *= 10;
        }
        transform.position = new Vector3(position.x, position.y);
    }

    private void ApplyForce(Vector2 force) {
        acceleration += force / mass;
    }

    private Vector2 AttractionForce() {

        if(typeBody == TypeBody.Planet) {
            Vector2 r = planetTwo.position - position;
            float rMagnitude = r.magnitude;
            Vector2 f = r.normalized * (planetTwo.mass * mass / rMagnitude * rMagnitude); // Fg = Ur * ((m1*m2/r^2)
            return f;
        }

        else {

            Vector2 r = sunAttraction.position - position;
            float rMagnitude = r.magnitude;
            Vector2 f = r.normalized * (sunAttraction.mass * mass / rMagnitude * rMagnitude); // Fg = Ur * ((m1*m2/r^2)
            return f;
        }
        
    }
}
