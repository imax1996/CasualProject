using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  ласс, определ€ющий UI дл€ стрелок.
/// </summary>
public class UIArrow : MonoBehaviour
{
    [Header("Set in Inspector: UIArrow")]
    Color grey = Color.grey;
    Color red = Color.red;
    Color green = Color.green;
    float animSpeed = 2;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeColorToRed()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(grey));
    }

    public void ChangeColorToGreen()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColor(green));
    }

    IEnumerator ChangeColor(Color setColor)
    {
        if (setColor == grey)
        {
            image.color = red;
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