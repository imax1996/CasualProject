using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameData _gameData;
    private Level _level;

    private void Awake()
    {
        _gameData = GetComponent<GameData>();
        _level = _gameData.LevelData.GetComponent<Level>();
    }

    private void Start()
    {
        _gameData.Menu.SetActive(true);
    }

    public void NewGame()
    {
        _level.StartLevel(1);
        _gameData.LevelData.CheckNextLevel.NextLevelEvent += OnNextLevel;
        _gameData.LevelData.Player.GetComponent<PlayerCollision>().DeathEvent += OnDeath;
        _gameData.Menu.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnNextLevel()
    {
        _level.StartLevel(_gameData.LevelData.Number + 1);
    }

    public void OnDeath()
    {
        _gameData.LevelData.CheckNextLevel.NextLevelEvent -= OnNextLevel;
        _gameData.LevelData.Player.GetComponent<PlayerCollision>().DeathEvent -= OnDeath;
        _gameData.Menu.SetActive(true);
    }
}
