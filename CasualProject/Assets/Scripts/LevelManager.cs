using UnityEngine;

/// <summary>
/// �����, ������������ ��������� ������.
/// </summary>
public class LevelManager : MonoBehaviour
{
    [Header("Set in Inspector: ZonesManager")]
    public CubeMove cubeMove;

    private LevelCreator    levelCreator;
    private GameObject      currentZone;
    private float           timeInputZone;
    private int             countOfObstacle;
    private int             maxKeys;

    private void Awake()
    {
        levelCreator = GetComponent<LevelCreator>();
    }

    /// <summary>
    /// �������� ��������� ��� ����� ����.
    /// </summary>
    public void ResetParameters()
    {
        Game.S.level = 1;
        countOfObstacle = 3;
        timeInputZone = 1f;
        maxKeys = 3;
    }

    /// <summary>
    /// ����������� ���������.
    /// </summary>
    public void IncreaseDifficult()
    {
        Game.S.level++;
        countOfObstacle++;
        timeInputZone = Mathf.Clamp(timeInputZone - 0.05f, 0.3f, 100f);
        maxKeys++;
    }

    /// <summary>
    /// ������� ������ �����������.
    /// </summary>
    public void DeleteObstacles()
    {
        if (currentZone != null)
        {
            Destroy(currentZone);
        }
    }

    /// <summary>
    /// ������ ����� �����������.
    /// </summary>
    public void CreateObstacles()
    {
        Level level = levelCreator.CreateLevel(countOfObstacle, timeInputZone, maxKeys, cubeMove.speed);

        currentZone = level.levelGO;
        cubeMove.pointToBackZ = level.leghthLevel;
    }
}