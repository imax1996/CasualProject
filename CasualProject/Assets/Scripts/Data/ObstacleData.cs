using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleData : MonoBehaviour
{
    public enum PosOnLevel {Left, Forward, Right }

    public PosOnLevel Entry;
    public PosOnLevel Exit;

    public InputZoneData InputZoneData;
    public GameObject Wall;

    public float Length;
}
