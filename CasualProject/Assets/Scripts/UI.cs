using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public static UI S;

    // [Header("Set in Inspector: UI")]
    [SerializeField] internal GameObject password;
    [SerializeField] GameObject arrow;

    [Header("Set Dynamically: UI")]
    int countOfmaxKey = 0;
    List<GameObject> arrows = new List<GameObject>();

    void Awake() {
        S = this;
    }

    public void ShowKey(InputKeys[] inputKeys) {
        if (inputKeys.Length > countOfmaxKey) {
            for (int i = 0; i < inputKeys.Length - countOfmaxKey; i++) {
                arrows.Add(Instantiate(arrow, password.transform) as GameObject);
            }
            countOfmaxKey = inputKeys.Length;
        }

        for(int i = 0; i < inputKeys.Length; i++) {
            switch (inputKeys[i]) {
                case InputKeys.Left:
                    arrows[i].transform.localRotation = Quaternion.Euler(0,0,0);
                    break;
                case InputKeys.Right:
                    arrows[i].transform.localRotation = Quaternion.Euler(0, 0, 180);
                    break;
            }
            arrows[i].SetActive(true);
        }
    }

    public void DisableArrow() {
        foreach (GameObject arrowsgo in arrows) {
            arrowsgo.SetActive(false);
        }
    }

    public void TakeInput() {
        arrow.SetActive(false);
    }
}