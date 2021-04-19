using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game S;

    [Header("Set in Inspector: Game")]
    public GameObject playerCube;

    //[Header("Set Dynamically: Game")]
    int             countOfObstacle;
    float           timeInputZone;
    int             maxKeys;
    LevelManager    levelManager;
    internal int    level;

    void Awake() {
        S = this;
        levelManager = GetComponent<LevelManager>();
    }

    public void ResetParameters() {
        level = 0;
        countOfObstacle = 3;
        timeInputZone = 1;
        maxKeys = 2;
    }

    void IncreaseDifficult() {
        level++;
        int ran = Random.Range(0, 3);
        switch (ran) {
            case 0:
                countOfObstacle++;
                break;
            case 1:
                timeInputZone -= 0.1f;
                break;
            case 2:
                maxKeys++;
                break;
        }
    }

    public void NewStart() {
        levelManager.DeleteZones();

        playerCube.transform.position = Vector3.zero;
        IncreaseDifficult();

        levelManager.CreateZones(countOfObstacle, timeInputZone, maxKeys);

        playerCube.SetActive(true);
        playerCube.GetComponent<CubeMove>().nextLevel = true;
        //загрузка завершена
    }
}