using UnityEngine;

/// <summary>
/// �����, ��������� �������.
/// </summary>
public class LevelCreator : MonoBehaviour
{
    [Header("Set in Inspector: Level")]
    [SerializeField] private Obstacle[] playerInside;
    [SerializeField] private Obstacle[] playerLeft;
    [SerializeField] private Obstacle[] playerRight;
    [SerializeField] private float timeUntilFirstZone = 3;
    [SerializeField] private float timeAfterLastZone = 1;
    [SerializeField] private InputKeys[] password;

    /// <summary>
    /// ������ ����������� �� ������.
    /// </summary>
    /// <param name="countOfObstacle">���-�� ������� �� ������.</param>
    /// <param name="timeInputZone">����� �� ���� ������ �������.</param>
    /// <param name="maxKeys">����������� ��������� ����� �����.</param>
    /// <param name="playerSpeed">�������� ������.</param>
    /// <returns></returns>
    public Level CreateLevel(int countOfObstacle, float timeInputZone, int maxKeys, float playerSpeed)
    {
        Level level = new Level();
        GameObject levelgo = new GameObject("Level");

        Vector3 posForObstacle = new Vector3(0, 0, timeUntilFirstZone * playerSpeed);

        for (int i = 0; i < countOfObstacle; i++)
        {
            Obstacle obstacle = ChooseObstacle(posForObstacle.x);
            obstacle.ChangeObstacle(timeInputZone, Random.Range(2, maxKeys), password, playerSpeed);

            Instantiate(obstacle.obstacle, posForObstacle, Quaternion.identity, levelgo.transform);

            posForObstacle.x += obstacle.playerPosXAfterObstacle;
            posForObstacle.z += obstacle.lengthObstacle.transform.position.z;
        }

        level.levelGO = levelgo;
        level.leghthLevel = posForObstacle.z + timeAfterLastZone * playerSpeed;

        return level;
    }

    /// <summary>
    /// ����� ����������� ������ �� ������� ������.
    /// </summary>
    /// <param name="posX">������� ������.</param>
    /// <returns></returns>
    private Obstacle ChooseObstacle(float posX)
    {
        if (Mathf.Approximately(posX, 0))
        {
            return playerInside[Random.Range(0, playerInside.Length)];
        }
        if (Mathf.Approximately(posX, -3))
        {
            return playerLeft[Random.Range(0, playerLeft.Length)];
        }
        if (Mathf.Approximately(posX, 3))
        {
            return playerRight[Random.Range(0, playerRight.Length)];
        }

        return null;
    }
}