using UnityEngine;

public class ObstaclesInstantiate : MonoBehaviour
{
    private ObstacleCreatorData _creatorData;

    [SerializeField] private ObstacleData[] LeftObstaclesPrefab;
    [SerializeField] private ObstacleData[] ForwardObstaclesPrefab;
    [SerializeField] private ObstacleData[] RightObstaclesPrefab;

    private void Awake()
    {
        _creatorData = GetComponent<ObstacleCreatorData>();
    }

    public void Init(int levelNumber)
    {
        int countObstacles = levelNumber + 2;

        _creatorData.Obstacles = new ObstacleData[countObstacles];
        ObstacleData[] obstaclesData = ForwardObstaclesPrefab;

        for (int i = 0; i < countObstacles; i++)
        {
            int ranObstacle = Random.Range(0, obstaclesData.Length);
            ObstacleData obstacle = obstaclesData[ranObstacle];
            _creatorData.Obstacles[i] = Instantiate(obstacle, _creatorData.AnchorObstacles.transform);
            obstaclesData = ChooseData(obstacle);
        }
    }

    private ObstacleData[] ChooseData(ObstacleData obstacle)
    {
        ObstacleData[] obstaclesData = null;

        if (obstacle.Exit == ObstacleData.PosOnLevel.Left)
        {
            if (obstacle.Entry == ObstacleData.PosOnLevel.Right)
            {
                obstaclesData = ForwardObstaclesPrefab;
            }
            else if(obstacle.Entry == ObstacleData.PosOnLevel.Forward)
            {
                obstaclesData = LeftObstaclesPrefab;
            }
        }
        else if(obstacle.Exit == ObstacleData.PosOnLevel.Right)
        {
            if (obstacle.Entry == ObstacleData.PosOnLevel.Left)
            {
                obstaclesData = ForwardObstaclesPrefab;
            }
            else if (obstacle.Entry == ObstacleData.PosOnLevel.Forward)
            {
                obstaclesData = RightObstaclesPrefab;
            }
        }
        return obstaclesData;
    }
}
