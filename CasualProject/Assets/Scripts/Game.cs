using UnityEngine;

/// <summary>
/// Класс, определяющий параметры игры.
/// </summary>
public class Game : MonoBehaviour
{
    public static Game S;

    [Header("Set in Inspector: Game")]
    public GameObject               playerCube;

    [HideInInspector] public int    level;
    private LevelManager            levelManager;

    private void Awake()
    {
        S = this;
        levelManager = GetComponent<LevelManager>();
    }

    /// <summary>
    /// Начинает новый уровень.
    /// </summary>
    public void StartLevel(bool isNextLevel)
    {
        if (isNextLevel == false)
        {
            levelManager.ResetParameters();
        }
        else
        {
            levelManager.IncreaseDifficult();
        }
        CreateLevel();
        EnablePlayer();
    }

    /// <summary>
    /// Создать уровень.
    /// </summary>
    private void CreateLevel() {
        levelManager.DeleteObstacles();
        levelManager.CreateObstacles();
    }

    /// <summary>
    /// Активирует игрока.
    /// </summary>
    private void EnablePlayer()
    {
        playerCube.transform.position = Vector3.zero;
        playerCube.SetActive(true);
        playerCube.GetComponent<CubeMove>().nextLevel = true;
    }
}