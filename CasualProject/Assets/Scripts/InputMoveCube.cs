using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoveCube : MonoBehaviour {
    // [Header("Set in Inspector: Input")]

    [Header("Set Dynamically: Input")]
    internal KeyCode        setKey;
    internal int            countOfInput;
    internal Queue<KeyCode> keyCodes;
     
    void Update() {
        if (countOfInput > 0) {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                CheckKey(KeyCode.LeftArrow);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                CheckKey(KeyCode.RightArrow);
            }
        }
    }

    void CheckKey(KeyCode key) {
        countOfInput--;
        if (key != setKey) {
            gameObject.SetActive(false);
        } else {
            keyCodes.Enqueue(key);
        }
    }
}