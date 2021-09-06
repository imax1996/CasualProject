using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LevelController _levelController;

    private int _level;

    private void Start()
    {
        _level = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartNewGame();
        }
    }

    private void StartNewGame()
    {
        _level++;
        _player.Init(_level);
        _levelController.CreateLevel(_level, _player.Speed);
        //включить прогресс-бар
    }
}
