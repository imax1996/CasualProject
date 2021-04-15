using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ќсновной скрипт игры.
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
    /// Ќачинает игру.
    /// </summary>
    void Start() {
        //создали игрока
        playerCube = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        moveCamera.player = playerCube;
        levelManager.cubeMove = playerCube.GetComponent<CubeMove>();

        //начали новый уровень
        NewStart();
    }

    /// <summary>
    /// Ќачинает новый уровень.
    /// </summary>
    public void NewStart() {
        //удалить старые зоны
        levelManager.DeleteZones();
        
        // переместить игрока в начало
        playerCube.transform.position = new Vector3(playerCube.transform.position.x, playerCube.transform.position.y, 0);

        //установить новые зоны
        levelManager.CreateZones();
    }
}