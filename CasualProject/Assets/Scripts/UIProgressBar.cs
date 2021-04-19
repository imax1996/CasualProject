using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour {
    // [Header("Set in Inspector: UIProgressBar")]
    public CubeMove player;
    public GameObject canvasProgress;
    public Image progressImage;
    public Text level0;
    public Text level1;

    // [Header("Set Dynamically: UIProgressBar")]

    void Update() {
        level0.text = (Game.S.level - 1).ToString();
        level1.text = Game.S.level.ToString();
        progressImage.fillAmount = Mathf.Clamp01(player.transform.position.z / player.pointToBackZ);
    }
}