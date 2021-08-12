using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс, определяющий UI для меню.
/// </summary>
public class UIMenu : MonoBehaviour {
    public static UIMenu S;

    [Header("Set in Inspector: UIMenu")]
    public GameObject   canvasProgress;
    public GameObject   canvasMenu;
    public Button       buttonStart;
    public Button       buttonExit;

    private void Awake()
    {
        S = this;
    }

    public void StartGame()
    {
        InteractableButtons(false);
        StartCoroutine(NewLevel(false));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Управляет интерактивностью кнопок.
    /// </summary>
    /// <param name="isEnabled">True - включает кнопки.</param>
    void InteractableButtons(bool isEnabled)
    {
        buttonStart.interactable = isEnabled;
        buttonExit.interactable = isEnabled;
    }

    /// <summary>
    /// Начинает новую игру.
    /// </summary>
    public IEnumerator NewLevel(bool isNextLevel)
    {
        StartCoroutine(UILevel.S.NextLevelFirstAnim());
        yield return new WaitForSeconds(1);

        if (isNextLevel == false)
        {
            canvasMenu.SetActive(false);
            canvasProgress.SetActive(true);
        }
        Game.S.StartLevel(isNextLevel);
        StartCoroutine(UILevel.S.NextLevelSecondAnim());
        yield return null;
    }

    public void GameOver()
    {
        StartCoroutine(OverGame());
    }

    /// <summary>
    /// Заканчивает игру.
    /// </summary>
    IEnumerator OverGame()
    {
        yield return new WaitForSeconds(1);
        canvasProgress.SetActive(false);
        InteractableButtons(true);
        canvasMenu.SetActive(true);
        yield return null;
    }
}