using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private Player          _player;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private UIProgress      _uiProgress;
    [SerializeField] private GameObject      _uiMenu;

    private int _level;

    private void Start()
    {
        _level = 0;
        _uiMenu.SetActive(true);
    }

    public void StartGame()
    {
        StartLevel();
        _player.NextLevelEvent += StartLevel;
        _player.GameOverEvent += GameOver;
        _uiMenu.SetActive(false);
    }

    private void StartLevel()
    {
        _level++;
        _player.Init(_level);
        float levelLength = _levelController.CreateLevel(_level, _player.GetComponent<PlayerAnimation>().Speed);
        _uiProgress.SetActiveTrue(_level, levelLength);
        _player.SetGoal(levelLength);
    }

    private void GameOver()
    {
        _level = 0;
        _uiProgress.SetActiveFalse();
        _player.NextLevelEvent -= StartLevel;
        _player.GameOverEvent -= GameOver;
        _uiMenu.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
