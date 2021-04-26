using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, определяющий UI для пароля.
/// </summary>
public class UIPassword : MonoBehaviour
{
    public static UIPassword S;

    [Header("Set in Inspector: UIPassword")]
    public GameObject password;
    [SerializeField] GameObject arrowPrefab;

    [Header("Set Dynamically: UIPassword")]
    public List<GameObject> arrows = new List<GameObject>();
    int countOfmaxKey;

    void Awake()
    {
        S = this;
    }

    /// <summary>
    /// Показывает пароль.
    /// </summary>
    /// <param name="inputKeys"></param>
    public void ShowKey(InputKeys[] inputKeys)
    {
        if (inputKeys.Length > countOfmaxKey) {
            for (int i = 0; i < inputKeys.Length - countOfmaxKey; i++)
            {
                arrows.Add(Instantiate(arrowPrefab, password.transform) as GameObject);
            }
            countOfmaxKey = inputKeys.Length;
        }

        for(int i = 0; i < inputKeys.Length; i++)
        {
            switch (inputKeys[i])
            {
                case InputKeys.Left:
                    arrows[i].transform.localRotation = Quaternion.Euler(0,0,0);
                    break;
                case InputKeys.Right:
                    arrows[i].transform.localRotation = Quaternion.Euler(0, 0, 180);
                    break;
                case InputKeys.Up:
                    arrows[i].transform.localRotation = Quaternion.Euler(0, 0, 270);
                    break;
                case InputKeys.Down:
                    arrows[i].transform.localRotation = Quaternion.Euler(0, 0, 90);
                    break;
            }
            arrows[i].SetActive(true);
        }
    }

    /// <summary>
    /// Отключает пароль.
    /// </summary>
    public void DisableArrow()
    {
        foreach (GameObject arrowsgo in arrows)
        {
            arrowsgo.SetActive(false);
        }
    }
}