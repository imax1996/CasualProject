using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {
    public GameObject levelGO;
    public float leghthLevel;
}

/// <summary>
/// Создаёт уровень.
/// </summary>
public class LevelManager : MonoBehaviour {
    [Header("Set in Inspector: ZonesManager")]
    [SerializeField] float timeUntilFirstZone;
    [SerializeField] float timeAfterLastZone;
    [SerializeField] int countOfObstacle;
    [SerializeField] float timeInputZone;
    [SerializeField] int maxKeys;
    [SerializeField] InputKeys[] password; 

    [Header("Set Dynamically: ZonesManager")]
    internal CubeMove cubeMove;

    LevelCreator    levelCreator;
    GameObject      currentZone;

    void Awake() {
        levelCreator = GetComponent<LevelCreator>();
    }

    public void DeleteZones() {
        if (currentZone != null) { Destroy(currentZone); }
    }

    public void CreateZones() {
        Level level = levelCreator.LevelCreate(timeUntilFirstZone, countOfObstacle, timeAfterLastZone, cubeMove.transform.position.x, timeInputZone, maxKeys, password, cubeMove.speed);

        currentZone = level.levelGO;
        cubeMove.pointToBackZ = level.leghthLevel;
    }
}