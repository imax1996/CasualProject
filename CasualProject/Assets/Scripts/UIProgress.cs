using UnityEngine;
using UnityEngine.UI;

public class UIProgress : MonoBehaviour
{
    [SerializeField] private GameObject _progressBarGO;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Text _textCurLevel;
    [SerializeField] private Text _textNextLevel;
    private float _lengthLevel;

    public void SetActiveFalse()
    {
        _progressBarGO.SetActive(false);
    }

    public void SetActiveTrue(int numOfLevel, float lengthLevel)
    {
        _progressBarGO.SetActive(true);
        _lengthLevel = lengthLevel;
        _textCurLevel.text = numOfLevel.ToString();
        _textNextLevel.text = (numOfLevel + 1).ToString();
    }

    private void LateUpdate()
    {
        _progressBar.fillAmount = _playerTransform.position.z / _lengthLevel;
    }
}
