using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Control Settings")]
    [SerializeField] private float speed = 1000f;
    [SerializeField] private float rotationSpeed = 100f;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotation, 0));
    }
}
