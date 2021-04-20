using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArrow : MonoBehaviour {
    [Header("Set in Inspector: UIArrow")]
    Color grey = Color.grey;
    Color red = Color.red;
    Color green = Color.green;
    [SerializeField] float speed = 1;

    // [Header("Set Dynamically: UIArrow")]
    Image image;

    void Awake() {
        image = GetComponent<Image>();
    }

    public void ChangeColorToRed() {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(grey));
    }

    public void ChangeColorToGreen() {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(green));
    }


    IEnumerator ChangeColor(Color setColor) {
        if (setColor == grey) {
            image.color = red;
        }

        float percent = 0;
        while (percent <= 1) {
            percent += Time.deltaTime * speed;
            image.color = Color.Lerp(image.color, setColor, percent);
            yield return null;
        }
    }

    void OnDisable() {
        image.color = grey;
    }
}