using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����, ������������ UI ��� ����.
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
        StartCoroutine(NewLevel());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// ��������� ���������������� ������.
    /// </summary>
    /// <param name="isEnabled">True - �������� ������.</param>
    void InteractableButtons(bool isEnabled)
    {
        buttonStart.interactable = isEnabled;
        buttonExit.interactable = isEnabled;
    }

    /// <summary>
    /// �������� ����� ����.
    /// </summary>
    IEnumerator NewLevel()
    {
        StartCoroutine(UILevel.S.NextLevelFirstAnim());
        yield return new WaitForSeconds(1);
        canvasMenu.SetActive(false);
        Game.S.StartNewLevel();
        canvasProgress.SetActive(true);
        StartCoroutine(UILevel.S.NextLevelSecondAnim());
        yield return null;
    }

    /// <summary>
    /// �������� ����� �������.
    /// </summary>
    public IEnumerator NextLevel()
    {
        StartCoroutine(UILevel.S.NextLevelFirstAnim());
        yield return new WaitForSeconds(1);
        Game.S.StartNextLevel();
        StartCoroutine(UILevel.S.NextLevelSecondAnim());
        yield return null;
    }

    public void GameOver()
    {
        StartCoroutine(OverGame());
    }

    /// <summary>
    /// ����������� ����.
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