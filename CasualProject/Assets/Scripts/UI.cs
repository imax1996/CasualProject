using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public static UI S;

    // [Header("Set in Inspector: UI")]
    [SerializeField] GameObject arrow;

    // [Header("Set Dynamically: UI")]

    void Awake() {
        S = this;
    }

    public void ShowKey(KeyCode key) {
        arrow.SetActive(true);

        switch (key) {
            case KeyCode.RightArrow:
                arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case KeyCode.LeftArrow:
                arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    public void TakeInput() {
        arrow.SetActive(false);
    }
}