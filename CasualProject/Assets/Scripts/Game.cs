using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ������ ����.
/// </summary>
public class Game : MonoBehaviour {
    public static Game S;

    [Header("Set in Inspector: Game")]
    [SerializeField] GameObject playerPrefab;

    [Header("Set Dynamically: Game")]
    MoveCamera      moveCamera;
    LevelManager    levelManager;
    GameObject      playerCube;

    void Awake() {
        S = this;
        moveCamera = Camera.main.GetComponent<MoveCamera>();
        levelManager = GetComponent<LevelManager>();
    }

    /// <summary>
    /// �������� ����.
    /// </summary>
    void Start() {
        //������� ������
        playerCube = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        moveCamera.player = playerCube;
        levelManager.cubeMove = playerCube.GetComponent<CubeMove>();

        //������ ����� �������
        NewStart();
    }

    /// <summary>
    /// �������� ����� �������.
    /// </summary>
    public void NewStart() {
        //������� ������ ����
        levelManager.DeleteZones();
        
        // ����������� ������ � ������
        playerCube.transform.position = new Vector3(playerCube.transform.position.x, playerCube.transform.position.y, 0);

        //���������� ����� ����
        levelManager.CreateZones();
    }
}