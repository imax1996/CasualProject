using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimator : MonoBehaviour {
    // [Header("Set in Inspector: CubeAnimator")]
    // [Header("Set Dynamically: CubeAnimator")]
    Animation anim;

    void Awake() {
        anim = GetComponent<Animation>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            anim.Play("Right");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            anim.Play("Left");
        }
    }
}