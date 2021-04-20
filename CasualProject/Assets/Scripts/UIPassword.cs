using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPassword : MonoBehaviour {
    public static UIPassword S;

    // [Header("Set in Inspector: UI")]
    [SerializeField] internal GameObject password;
    [SerializeField] GameObject arrowPrefab;

    [Header("Set Dynamically: UI")]
    int countOfmaxKey = 0;
    public List<GameObject> arrows = new List<GameObject>();

    void Awake() {
        S = this;
    }

    public void ShowKey(InputKeys[] inputKeys) {
        if (inputKeys.Length > countOfmaxKey) {
            for (int i = 0; i < inputKeys.Length - countOfmaxKey; i++) {
                arrows.Add(Instantiate(arrowPrefab, password.transform) as GameObject);
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
                case InputKeys.Up:
                    arrows[i].transform.localRotation = Quaternion.Euler(0, 0, 270);
                    break;
                case InputKeys.Down:
                    arrows[i].transform.localRotation = Quaternion.Euler(0, 0, 90);
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
        arrowPrefab.SetActive(false);
    }
}