using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour {
    public static UILevel S;

    [Header("Set in Inspector: UILevel")]
    public GameObject imageFade;

    // [Header("Set Dynamically: UILevel")]
    Image image;

    void Awake() {
        S = this;
        image = imageFade.GetComponent<Image>();
    }

    public void StartCor(int i) {
        switch (i) {
            case 1:
                StartCoroutine(AnimStartLevel());
                break;
            case 2:
                StartCoroutine(AnimUntilLoadLevel());
                break;
        }
    }

    public IEnumerator AnimStartLevel() {
        float percent = 0;
        while (percent <= 1) {
            percent += Time.deltaTime;
            imageFade.transform.localScale = Vector3.one * Mathf.Lerp(0,3,percent);
            image.color = new Color(0, 1, 1, Mathf.Lerp(0, 1, percent));
            yield return null;
        }

        //начинай загрузку
        Game.S.StartAndOverGame(true);
    }

    public IEnumerator AnimUntilLoadLevel() {
        float percent = 0;
        imageFade.transform.localScale = Vector3.one * 3;
        image.color = new Color(0,1,1,1);

        while (percent <= 1) {
            percent += Time.deltaTime;
            image.color = new Color(0, 1, 1, Mathf.Lerp(1,0,percent));
            yield return null;
        }

        imageFade.transform.localScale = Vector3.zero;

        Game.S.StartAndOverGame(false);
    }
}