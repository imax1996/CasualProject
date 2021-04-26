using UnityEngine;

public class LevelManager : MonoBehaviour {
    [Header("Set in Inspector: ZonesManager")]
    [SerializeField] float timeUntilFirstZone = 3;
    [SerializeField] float timeAfterLastZone = 2;

    [Header("Set Dynamically: ZonesManager")]
    [SerializeField] InputKeys[] password;

    public CubeMove cubeMove;

    LevelCreator    levelCreator;
    GameObject      currentZone;

    void Awake() {
        levelCreator = GetComponent<LevelCreator>();
    }

    public void DeleteZones() {
        if (currentZone != null) { Destroy(currentZone); }
    }

    public void CreateZones(int countOfObstacle, float timeInputZone, int maxKeys) {

        Level level = levelCreator.LevelCreate(timeUntilFirstZone, countOfObstacle, timeAfterLastZone, cubeMove.transform.position.x, timeInputZone, maxKeys, password, cubeMove.speed);

        currentZone = level.levelGO;
        cubeMove.pointToBackZ = level.leghthLevel;

        countOfObstacle++;
        timeInputZone -= 0.1f;
        maxKeys++;

    }
}