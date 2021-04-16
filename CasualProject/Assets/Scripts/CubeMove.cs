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
    InputMoveCube   im;
    Rigidbody       rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        im = GetComponent<InputMoveCube>();
    }

    void FixedUpdate() {
        rb.velocity = Vector3.forward * speed;
    }

    void LateUpdate() {
        if (transform.position.z >= pointToBackZ) {
            Game.S.NewStart();
        }
    }

    void OnTriggerEnter(Collider other) {
        im.keyCodes = new Queue<KeyCode>();
        im.countOfInput = 1;
        im.setKey = other.GetComponent<Zone>().key;
        UI.S.ShowKey(im.setKey);
    }

    void OnTriggerExit(Collider other) {
        im.countOfInput = 0;
        if (im.keyCodes.Count > 0) {
            StartCoroutine(Move(im.keyCodes.Dequeue()));
        }
        UI.S.TakeInput();
    }

    IEnumerator Move(KeyCode key) {
        float posCurX = transform.position.x;
        float posTarX = posCurX;

        switch (key) {
            case KeyCode.LeftArrow:
                posTarX -= 3;
                break;
            case KeyCode.RightArrow:
                posTarX += 3;
                break;
        }

        float percent = 0;
        float speedAnimation = 0.2f;

        while (percent <= 1) {
            percent += Time.deltaTime / speedAnimation;
            transform.position = new Vector3(Mathf.Lerp(posCurX, posTarX, percent), transform.position.y, transform.position.z);
            yield return null;
        }
    }
}