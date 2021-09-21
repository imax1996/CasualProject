using UnityEngine;

public class ObstaclesCreator : MonoBehaviour
{
    private ObstacleCreatorData _creatorData;

    private ObstaclesInstantiate _obstaclesInstantiate;
    private ObstaclesCustomization _obstaclesCustomization;

    private void Awake()
    {
        _creatorData = GetComponent<ObstacleCreatorData>();
        _obstaclesInstantiate = GetComponent<ObstaclesInstantiate>();
        _obstaclesCustomization = GetComponent<ObstaclesCustomization>();
    }

    public void Init(int levelNumber, float speedPlayer)
    {
        if (_creatorData.AnchorObstacles != null)
        {
            Destroy(_creatorData.AnchorObstacles);
        }
        _creatorData.AnchorObstacles = new GameObject("Obstacles");

        _obstaclesInstantiate.Init(levelNumber);
        _obstaclesCustomization.Init(levelNumber, speedPlayer);
    }
}
