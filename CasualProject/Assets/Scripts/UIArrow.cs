using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс, определяющий UI для стрелок.
/// </summary>
public class UIArrow : MonoBehaviour
{
    private Color grey = Color.grey;
    private Color red = Color.red;
    private Color green = Color.green;
    private float animSpeed = 2;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeColorToRed()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(red));
    }

    public void ChangeColorToGreen()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(green));
    }

    IEnumerator ChangeColor(Color setColor)
    {
        if (setColor == red)
        {
            image.color = red;
            setColor = grey;
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
        image.color = grey;
    }
}