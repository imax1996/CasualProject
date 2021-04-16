using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {
    public GameObject levelGO;
    public float leghthLevel;
}

public class LevelCreator : MonoBehaviour{
    [Header("Set in Inspector: Level")]
    [SerializeField] Obstacle[] playerInside;
    [SerializeField] Obstacle[] playerLeft;
    [SerializeField] Obstacle[] playerRight;

    //[Header("Set Dynamically: Level")]

    public Level LevelCreate(float untilFirstZone, int countOfObstacle, float aterLastZone, float playerPosX, float timeInputZone) {
        Level level = new Level();
        GameObject levelgo = new GameObject("Level");

        Vector3 posForObstacle = new Vector3(playerPosX, 0, untilFirstZone);

        for (int i = 0; i < countOfObstacle; i++) {
            Obstacle obstacle = ChooseObstacle(posForObstacle.x);
            obstacle.Change(timeInputZone);

            Instantiate(obstacle.obstacle, posForObstacle, Quaternion.identity, levelgo.transform);

            posForObstacle.x += obstacle.playerPosXAfterObstacle;
            posForObstacle.z += obstacle.lengthObstacle.transform.position.z;
        }

        level.levelGO = levelgo;
        level.leghthLevel = posForObstacle.z + aterLastZone;

        return level;
    }

    Obstacle ChooseObstacle(float posX) {
        //выбор препятствия должен быть исходя из места игрока
        if (Mathf.Approximately(posX, 0)) {
            return playerInside[Random.Range(0, playerInside.Length)];
        }
        else if (Mathf.Approximately(posX, -3)) {
            return playerLeft[Random.Range(0, playerLeft.Length)];
        }
        else if (Mathf.Approximately(posX, 3)) {
            return playerRight[Random.Range(0, playerRight.Length)];
        }

        return null;
    }
}