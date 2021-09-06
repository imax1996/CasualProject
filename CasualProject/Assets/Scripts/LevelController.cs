using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private LevelModel _levelModel;
    private LevelView _levelView;
    private GameObject _level;
    private int minCountOfInputs = 2;
    private float changeTimeToOneInputPerLevel = 0.025f;

    private void Awake()
    {
        _levelView = GetComponent<LevelView>();
    }

    public void CreateLevel(int numOflevel, float speedPlayer)
    {
        if (_level != null)
        {
            Destroy(_level);
        }

        int countOfObstacles = numOflevel + 2;
        Vector2Int rangeOfInputs = new Vector2Int(minCountOfInputs, Mathf.Max(minCountOfInputs, numOflevel + 2));
        float timeToOneInput = 1f - changeTimeToOneInputPerLevel * (numOflevel - 1);

        _levelModel = new LevelModel(countOfObstacles, rangeOfInputs, timeToOneInput, speedPlayer);
        _level = _levelView.CreateLevel(_levelModel);
    }
}
