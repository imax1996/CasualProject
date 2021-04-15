using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Двигает куб.
/// </summary>
public class CubeMove : MonoBehaviour {
    [Header("Set in Inspector: CubeMove")]
    [SerializeField] internal float speed = 5;
    [SerializeField] internal float pointToBackZ = 100;

    [Header("Set Dynamically: CubeMove")]
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.velocity = Vector3.forward * speed;
    }

    void LateUpdate() {
        if (transform.position.z >= pointToBackZ) {
            Game.S.NewStart();
        }
    }
}