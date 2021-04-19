using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
    [Header("Set in Inspector: CubeMove")]
    [SerializeField] internal float speed = 10;
    [SerializeField] internal float pointToBackZ = 100;

    [Header("Set Dynamically: CubeMove")]
    Rigidbody       rb;

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

    void OnCollisionEnter(Collision collision) {
        //game over
        gameObject.SetActive(false);
        StartCoroutine(UILevel.S.AnimUntilLoadLevel());
    }

    void OnTriggerEnter(Collider other) {
        InputPassword.S.enabled = true;
        InputPassword.S.GetPassword(other.GetComponent<Zone>());
    }

    void OnTriggerExit(Collider other) {
        StartCoroutine(Move(InputPassword.S.Move()));
    }

    IEnumerator Move(ActionMove move) {
        float posCurX = transform.position.x;
        float posTarX = posCurX;

        switch (move) {
            case ActionMove.None:
                posTarX += 0;
                break;
            case ActionMove.Right:
                posTarX += 3;
                break;
            case ActionMove.Left:
                posTarX -= 3;
                break;
        }

        float percent = 0;

        while (percent <= 1) {
            percent += Time.deltaTime * speed;
            transform.position = new Vector3(Mathf.Lerp(posCurX, posTarX, percent), transform.position.y, transform.position.z);
            yield return null;
        }
    }
}