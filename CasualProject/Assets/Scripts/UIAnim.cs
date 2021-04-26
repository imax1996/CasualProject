using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIAnim : MonoBehaviour {
    public static UIAnim S;

    [Header("Set in Inspector: UIMenu")]
    public GameObject   canvasProgress;
    public GameObject   canvasMenu;
    public Button       buttonStart;
    public Button       buttonExit;

    void Awake() {
        S = this;
    }

    public void StartGame() {
        ButtonIsInteract(false);
        StartCoroutine(StartButton());
    }

    public void ExitGame() {
        Application.Quit();
    }

    void ButtonIsInteract(bool isEnabled) {
        buttonStart.interactable = isEnabled;
        buttonExit.interactable = isEnabled;
    }

    IEnumerator StartButton() {
        StartCoroutine(UILevel.S.NextLevelFirstAnim());
        yield return new WaitForSeconds(1);
        canvasMenu.SetActive(false);
        Game.S.ResetParameters();
        Game.S.NewStart();
        canvasProgress.SetActive(true);
        StartCoroutine(UILevel.S.NextLevelSecondAnim());
        yield return null;
    }

    public IEnumerator NextLevel() {
        StartCoroutine(UILevel.S.NextLevelFirstAnim());
        yield return new WaitForSeconds(1);
        Game.S.NewStart();
        StartCoroutine(UILevel.S.NextLevelSecondAnim());
        yield return null;
    }

    public void GameOver() {
        StartCoroutine(IGameOver());
    }

    IEnumerator IGameOver() {
        yield return new WaitForSeconds(1);
        canvasProgress.SetActive(false);
        ButtonIsInteract(true);
        canvasMenu.SetActive(true);
        yield return null;
    }
}