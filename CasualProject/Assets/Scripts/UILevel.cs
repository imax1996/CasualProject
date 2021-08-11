using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс, определяющий UI для уровня.
/// </summary>
public class UILevel : MonoBehaviour
{
    public static UILevel S;

    [Header("Set in Inspector: UILevel")]
    public GameObject   imageFade;

    [Header("Set Dynamically: UILevel")]
    private Image       image;

    private void Awake()
    {
        S = this;
        image = imageFade.GetComponent<Image>();
    }

    /// <summary>
    /// Анимация фейда с увеличением.
    /// </summary>
    /// <returns></returns>
    public IEnumerator NextLevelFirstAnim()
    {
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime;
            imageFade.transform.localScale = Vector3.one * Mathf.Lerp(0,3,percent);
            image.color = new Color(0, 1, 1, Mathf.Lerp(0, 1, percent));
            yield return null;
        }
    }

    /// <summary>
    /// Анимация фейда с исчезновением.
    /// </summary>
    /// <returns></returns>
    public IEnumerator NextLevelSecondAnim()
    {
        float percent = 0;
        imageFade.transform.localScale = Vector3.one * 3;
        image.color = new Color(0,1,1,1);

        while (percent <= 1)
        {
            percent += Time.deltaTime;
            image.color = new Color(0, 1, 1, Mathf.Lerp(1,0,percent));
            yield return null;
        }

        imageFade.transform.localScale = Vector3.zero;
    }
}