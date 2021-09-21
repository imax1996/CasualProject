using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public float _speedAnimation;
    public Image arrow;

    private void Awake()
    {
        arrow = GetComponent<Image>();
    }

    public void Animate(bool isRightAnim)
    {
        StopAllCoroutines();
        StartCoroutine(RightAnim(isRightAnim));
    }

    private IEnumerator RightAnim(bool isRight)
    {
        Color color1 = Color.white;
        Color color2 = Color.green;
        if (!isRight)
        {
            color1 = Color.red;
            color2 = Color.white;
        }
        float timeProgress = 0;
        float timeAnimation = 1 / _speedAnimation;
        while (timeProgress < timeAnimation)
        {
            arrow.color = Color.Lerp(color1, color2, timeProgress / timeAnimation);
            timeProgress += Time.deltaTime;
            yield return null;
        }
    }

    private void OnDisable()
    {
        arrow.color = Color.white;
    }
}
