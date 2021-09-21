using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCustomization : MonoBehaviour
{
    private ObstacleCreatorData _creatorData;

    public float timeToOneInputFirstLevel;
    public float offsetTimeToInputOnLevel;
    public float timeBeforeFirstObstacle;
    public float timeAfterLastObstacle;

    private void Awake()
    {
        _creatorData = GetComponent<ObstacleCreatorData>();
    }

    public void Init(int levelNumber, float speedPlayer)
    {
        ObstacleData[] obstacles = _creatorData.Obstacles;
        Vector3 obstaclePos = new Vector3(0, 0, timeBeforeFirstObstacle * speedPlayer);

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Obstacle>().Init(levelNumber, (timeToOneInputFirstLevel - offsetTimeToInputOnLevel * levelNumber) * speedPlayer);
            obstacles[i].transform.position = obstaclePos;

            float posX = obstaclePos.x + ExitFloat(obstacles[i].Exit);
            float posZ = obstaclePos.z + obstacles[i].Length;
            obstaclePos = new Vector3(posX, 0, posZ);
        }

        _creatorData.Length = obstaclePos.z + timeAfterLastObstacle * speedPlayer;
    }

    private float ExitFloat(ObstacleData.PosOnLevel exitPos)
    {
        float offset = 0;

        switch (exitPos)
        {
            case ObstacleData.PosOnLevel.Left:
                offset = -3;
                break;
            case ObstacleData.PosOnLevel.Right:
                offset = 3;
                break;
        }

        return offset;
    }
}
