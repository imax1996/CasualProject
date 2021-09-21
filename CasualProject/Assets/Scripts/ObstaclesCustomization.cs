using UnityEngine;

public class ObstaclesCustomization : MonoBehaviour
{
    private ObstacleCreatorData _creatorData;

    [SerializeField] private float _timeToOneInputFirstLevel;
    [SerializeField] private float _offsetTimeToInputOnLevel;
    [SerializeField] private float _timeBeforeFirstObstacle;
    [SerializeField] private float _timeAfterLastObstacle;

    private void Awake()
    {
        _creatorData = GetComponent<ObstacleCreatorData>();
    }

    public void Init(int levelNumber, float speedPlayer)
    {
        ObstacleData[] obstacles = _creatorData.Obstacles;
        Vector3 obstaclePos = new Vector3(0, 0, _timeBeforeFirstObstacle * speedPlayer);

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Obstacle>().Init(levelNumber, (_timeToOneInputFirstLevel - _offsetTimeToInputOnLevel * levelNumber) * speedPlayer);
            obstacles[i].transform.position = obstaclePos;

            float posX = obstaclePos.x + ExitFloat(obstacles[i].Exit);
            float posZ = obstaclePos.z + obstacles[i].Length;
            obstaclePos = new Vector3(posX, 0, posZ);
        }

        _creatorData.Length = obstaclePos.z + _timeAfterLastObstacle * speedPlayer;
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
