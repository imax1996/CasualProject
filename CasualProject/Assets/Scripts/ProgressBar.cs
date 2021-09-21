using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Text CurLevel;
    public Text NextLevel;
    public Image Field;

    public Transform Target;
    public float LengthLevel;

    public void Init(int numberLevel, float lengthLevel)
    {
        CurLevel.text = numberLevel.ToString();
        NextLevel.text = (numberLevel + 1).ToString();
        LengthLevel = lengthLevel;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        Field.fillAmount = Mathf.Clamp01(Target.position.z / LengthLevel);
    }
}
