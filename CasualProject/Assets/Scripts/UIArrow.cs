using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс, определяющий UI для стрелок.
/// </summary>
public class UIArrow : MonoBehaviour
{
    private float animSpeed = 2;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeColorToColor(Color color)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(color));
    }

    IEnumerator ChangeColor(Color setColor)
    {
        if (setColor == Color.red)
        {
            image.color = Color.red;
            setColor = Color.grey;
        }

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * animSpeed;
            image.color = Color.Lerp(image.color, setColor, percent);
            yield return null;
        }
    }

    void OnDisable()
    {
        image.color = Color.grey;
    }
}