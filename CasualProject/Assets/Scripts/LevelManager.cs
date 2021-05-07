using UnityEngine;

/// <summary>
///  ласс, определ¤ющий параметры уровн¤.
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
    /// ќбнул¤ет сложность дл¤ новой игры.
    /// </summary>
    public void ResetParameters()
    {
        Game.S.level = 1;
        countOfObstacle = 3;
        timeInputZone = 1f;
        maxKeys = 3;
    }

    /// <summary>
    /// ”величивает сложность.
    /// </summary>
    public void IncreaseDifficult()
    {
        Game.S.level++;
        countOfObstacle++;
        timeInputZone = Mathf.Clamp(timeInputZone - 0.05f, 0.3f, 100f);
        maxKeys++;
    }

    /// <summary>
    /// ”дал¤ет старые преп¤тстви¤.
    /// </summary>
    public void DeleteObstacles()
    {
        if (currentZone != null)
        {
            Destroy(currentZone);
        }
    }

    /// <summary>
    /// —оздаЄт новые преп¤тстви¤.
    /// </summary>
    public void CreateObstacles()
    {
        Level level = levelCreator.CreateLevel(countOfObstacle, timeInputZone, maxKeys, cubeMove.speed);

        currentZone = level.levelGO;
        cubeMove.pointToBackZ = level.leghthLevel;
    }
}