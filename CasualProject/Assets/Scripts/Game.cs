using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game S;

    [Header("Set in Inspector: Game")]
    public GameObject canvasUIMenu;
    public GameObject playerCube;

    //[Header("Set Dynamically: Game")]
    LevelManager    levelManager;
    int             level;

    void Awake() {
        S = this;
        levelManager = GetComponent<LevelManager>();
    }

    public void StartAndOverGame(bool isStart) {
        canvasUIMenu.SetActive(!isStart);
        playerCube.SetActive(isStart);
        if (isStart) {
            NewStart();
        }
    }

    public void NewStart() {
        levelManager.DeleteZones();
        
        playerCube.transform.position = new Vector3(playerCube.transform.position.x, playerCube.transform.position.y, 0);
        level++;

        levelManager.CreateZones();

        StartCoroutine(UILevel.S.AnimUntilLoadLevel());
    }
}