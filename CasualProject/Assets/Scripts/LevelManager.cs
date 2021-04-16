using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ �������.
/// </summary>
public class LevelManager : MonoBehaviour {
    [Header("Set in Inspector: ZonesManager")]
    [SerializeField] float timeUntilFirstZone;
    [SerializeField] float timeAfterLastZone;
    [SerializeField] int countOfObstacle;
    [SerializeField] float timeInputZone;

    [Header("Set Dynamically: ZonesManager")]
    internal CubeMove cubeMove;

    LevelCreator    levelCreator;
    GameObject      currentZone;

    void Awake() {
        levelCreator = GetComponent<LevelCreator>();
    }

    public void DeleteZones() {
        if (currentZone != null) { Destroy(currentZone); }
    }

    public void CreateZones() {
        /* 
         * ������ ��� ������� ������ ��:
         * ����� �� ����� �� ����� � �� ��������� 10 (cubeMove.speed)
         * ��� ����������� ��� � ������������ ��� �������
         * ����� �� ������
         * � ����� �� ������� �����
         */

        Level level = levelCreator.LevelCreate(timeUntilFirstZone * cubeMove.speed, countOfObstacle, timeAfterLastZone * cubeMove.speed, cubeMove.transform.position.x, timeInputZone);

        currentZone = level.levelGO;
        cubeMove.pointToBackZ = level.leghthLevel;
    }
}