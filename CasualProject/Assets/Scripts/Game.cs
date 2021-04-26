using UnityEngine;

/// <summary>
/// Класс, определяющий параметры игры.
/// </summary>
public class Game : MonoBehaviour
{
    public static Game S;

    [Header("Set in Inspector: Game")]
    [HideInInspector] public int    level;
    public GameObject               playerCube;
    private LevelManager            levelManager;

    private void Awake()
    {
        S = this;
        levelManager = GetComponent<LevelManager>();
    }

    /// <summary>
    /// Начинает новый уровень.
    /// </summary>
    public void StartNewLevel()
    {
        levelManager.ResetParameters();
        CreateLevel();
        EnablePlayer();
    }

    /// <summary>
    /// Начинает следующий уровень.
    /// </summary>
    public void StartNextLevel()
    {
        levelManager.IncreaseDifficult();
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