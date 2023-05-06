using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Control Settings")]
    private float rotationSpeed = 100f;
    public float speed = 1000f;
    public string name;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        name = gameObject.name;
    }

    void FixedUpdate() {
        rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotation, 0));
    }

    public void IncreaseSpeed() {
        speed += 200f;
    }

    public void DecreaseSpeed() {
        speed -= 200f;
    }
}
