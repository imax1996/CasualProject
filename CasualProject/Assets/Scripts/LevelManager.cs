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
         * ������ ��� ���� ������ ��:
         * ����� �� ����� �� ����� � �� ��������� 5 (cubeMove.speed)
         * ��� ����������� ��� � ������������ ��� �������
         * ����� �� ������
         * � ����� �� ������� �����
         */

        Level level = levelCreator.LevelCreate(timeUntilFirstZone * cubeMove.speed, countOfObstacle, timeAfterLastZone * cubeMove.speed, cubeMove.transform.position.x);

        currentZone = level.levelGO;
        cubeMove.pointToBackZ = level.leghthLevel;
    }
}