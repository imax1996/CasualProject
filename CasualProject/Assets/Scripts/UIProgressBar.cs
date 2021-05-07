using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  ласс, определ¤ющий UI дл¤ прогресс-бара.
/// </summary>
public class UIProgressBar : MonoBehaviour
{
    [Header("Set in Inspector: UIProgressBar")]
    public CubeMove     player;
    public GameObject   canvasProgress;
    public Image        progressImage;
    public Text         level0;
    public Text         level1;

    void Update()
    {
        level0.text = (Game.S.level - 1).ToString();
        level1.text = Game.S.level.ToString();
        progressImage.fillAmount = Mathf.Clamp01(player.transform.position.z / player.pointToBackZ);
    }
}