using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour {
    public Button buttonStart;
    public Button buttonExit;

    public void StartGame() {
        ButtonBoolean(false);
        StartCoroutine(UILevel.S.AnimStartLevel());
    }

    public void ExitGame() {
        Application.Quit();
    }

    void ButtonBoolean(bool IsInteractable) {
        buttonStart.interactable = IsInteractable;
        buttonExit.interactable = IsInteractable;
    }
}