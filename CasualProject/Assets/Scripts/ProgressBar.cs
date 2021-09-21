using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Text CurLevel;
    [SerializeField] private Text NextLevel;
    [SerializeField] private Image Field;

    [SerializeField] private Transform Target;
    [SerializeField] private float LengthLevel;

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
