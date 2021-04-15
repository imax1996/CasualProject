using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {
    public GameObject levelGO;
    public float leghthLevel;
}

public class LevelCreator : MonoBehaviour{
    [Header("Set in Inspector: Level")]
    [SerializeField] GameObject[] playerInside;
    [SerializeField] GameObject[] playerLeft;
    [SerializeField] GameObject[] playerRight;

    //[Header("Set Dynamically: Level")]

    public Level LevelCreate(float untilFirstZone, int countOfObstacle, float aterLastZone, float playerPosX) {
        Level level = new Level();
        GameObject levelgo = new GameObject("Level");

        Vector3 posForObstacle = new Vector3(playerPosX, 0, untilFirstZone);

        for (int i = 0; i < countOfObstacle; i++) {
            Instantiate(ChooseObstacle(), posForObstacle, Quaternion.identity, levelgo.transform);
        }

        level.levelGO = levelgo;
        level.leghthLevel = 10;

        return level;
    }

    GameObject ChooseObstacle() {
        //выбор препятствия должен быть исходя из места игрока


        return new GameObject();
    }
}