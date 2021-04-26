using UnityEngine;

/// <summary>
/// �����, ������������ ��������� ����.
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
    /// �������� ����� �������.
    /// </summary>
    public void StartNewLevel()
    {
        levelManager.ResetParameters();
        CreateLevel();
        EnablePlayer();
    }

    /// <summary>
    /// �������� ��������� �������.
    /// </summary>
    public void StartNextLevel()
    {
        levelManager.IncreaseDifficult();
        CreateLevel();
        EnablePlayer();
    }

    /// <summary>
    /// ������� �������.
    /// </summary>
    private void CreateLevel() {
        levelManager.DeleteObstacles();
        levelManager.CreateObstacles();
    }

    /// <summary>
    /// ���������� ������.
    /// </summary>
    private void EnablePlayer()
    {
        playerCube.transform.position = Vector3.zero;
        playerCube.SetActive(true);
        playerCube.GetComponent<CubeMove>().nextLevel = true;
    }
}