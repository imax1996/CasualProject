using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
    [Header("Set in Inspector: CubeMove")]
    [SerializeField] internal float speed = 10;
    [SerializeField] internal float pointToBackZ = 100;

    [Header("Set Dynamically: CubeMove")]
    internal bool nextLevel;

    Rigidbody   rb;
    float       offsetX;
    float       offset = 0;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.velocity = Vector3.forward * speed;

        if (offset > 0) {
            float _offsetX = offsetX * Time.fixedDeltaTime * speed/2;
            Vector3 newPos;
            if (Mathf.Abs(_offsetX) > Mathf.Abs(offset)) {
                newPos = transform.position + Vector3.right * offset * Mathf.Sign(offsetX);
            } else {
                newPos = transform.position + Vector3.right * _offsetX;
            }
            offset -= Mathf.Abs(_offsetX);
            rb.MovePosition(newPos);
        }
    }

    void LateUpdate() {
        if (transform.position.z >= pointToBackZ && nextLevel) {
            //выигрыш
            nextLevel = false;
            StartCoroutine(UIAnim.S.NextLevel());
        }
    }

    void OnCollisionEnter(Collision collision) {
        //game over
        gameObject.SetActive(false);
        UIAnim.S.GameOver();
    }

    void OnTriggerEnter(Collider other) {
        InputPassword.S.enabled = true;
        InputPassword.S.GetPassword(other.GetComponent<Zone>());
    }

    void OnTriggerExit(Collider other) {
        switch (InputPassword.S.Move()) {
            case ActionMove.Right:
                offsetX = 3;
                break;
            case ActionMove.Left:
                offsetX = -3;
                break;
        }
        offset = 3;
    }
}