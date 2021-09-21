using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputZoneData : MonoBehaviour
{
    public enum Direction { Right, Up, Left, Down}

    public Direction[] Directions;
    public ObstacleData.PosOnLevel Exit;
}
