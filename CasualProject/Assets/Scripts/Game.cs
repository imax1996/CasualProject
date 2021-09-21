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

    public void NewGame()
    {
        _gameData.Fade.AnimEndEvent += NewGameAfterAnim;
        _gameData.Fade.FadeOut();
    }

    private void NewGameAfterAnim()
    {
        _gameData.Fade.AnimEndEvent -= NewGameAfterAnim;
        _gameData.Menu.SetActive(false);
        _level.StartLevel(1);
        _gameData.LevelData.CheckNextLevel.NextLevelEvent += OnNextLevel;
        _gameData.LevelData.Player.GetComponent<PlayerCollision>().DeathEvent += OnDeath;
        _gameData.Fade.FadeIn();
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
        _gameData.Fade.AnimEndEvent += NextLevelAfterAnim;
        _gameData.Fade.FadeOut();
    }

    private void NextLevelAfterAnim()
    {
        _gameData.Fade.AnimEndEvent -= NextLevelAfterAnim;
        _level.StartLevel(_gameData.LevelData.Number + 1);
        _gameData.Fade.FadeIn();
    }

    public void OnDeath()
    {
        _gameData.LevelData.CheckNextLevel.NextLevelEvent -= OnNextLevel;
        _gameData.LevelData.Player.GetComponent<PlayerCollision>().DeathEvent -= OnDeath;
        _gameData.Menu.SetActive(true);
    }
}
