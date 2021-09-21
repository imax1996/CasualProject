using UnityEngine;

public class InputZone : MonoBehaviour
{
    public void Init(int numLevel, ObstacleData.PosOnLevel exitPos)
    {
        InputZoneData zoneData = GetComponent<InputZoneData>();
        zoneData.Exit = exitPos;
        int countDirections = Random.Range(2, numLevel + 3);
        zoneData.Directions = new InputZoneData.Direction[countDirections];
        for (int i = 0; i < countDirections; i++)
        {
            zoneData.Directions[i] = (InputZoneData.Direction)Random.Range(0, 4);
        }
    }
}
