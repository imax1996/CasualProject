using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour{
    [Header("Set in Inspector: Level")]
    [SerializeField] Obstacle[] playerInside;
    [SerializeField] Obstacle[] playerLeft;
    [SerializeField] Obstacle[] playerRight;

    //[Header("Set Dynamically: Level")]

    public Level LevelCreate(float timeUntilFirstZone, int countOfObstacle, float timeAterLastZone, float playerPosX, float timeInputZone, int maxKeys, InputKeys[] password, float playerSpeed) {
        Level level = new Level();
        GameObject levelgo = new GameObject("Level");

        Vector3 posForObstacle = new Vector3(playerPosX, 0, timeUntilFirstZone * playerSpeed);

        for (int i = 0; i < countOfObstacle; i++) {
            Obstacle obstacle = ChooseObstacle(posForObstacle.x);
            obstacle.Change(timeInputZone, Random.Range(2, maxKeys), password, playerSpeed);

            Instantiate(obstacle.obstacle, posForObstacle, Quaternion.identity, levelgo.transform);

            //показать зоне возможные кнопки

            posForObstacle.x += obstacle.playerPosXAfterObstacle;
            posForObstacle.z += obstacle.lengthObstacle.transform.position.z;
        }

        level.levelGO = levelgo;
        level.leghthLevel = posForObstacle.z + timeAterLastZone * playerSpeed;

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