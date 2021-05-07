using UnityEngine;

/// <summary>
///  ласс, определ¤ющий преп¤тствие.
/// </summary>
public class Obstacle : MonoBehaviour
{
    [Header("Set in Inspector: Obstacle")]
    public GameObject   obstacle;
    public GameObject   inputZone;
    public GameObject   cubes;
    public GameObject   lengthObstacle;
    [HideInInspector] public float        playerPosXAfterObstacle;

    /// <summary>
    /// »змен¤ет шаблон преп¤тстви¤ под параметры уровн¤.
    /// </summary>
    /// <param name="timeInputZone">¬рем¤ на ввод одного символа.</param>
    /// <param name="keys"> ол-во симвлолов ввода.</param>
    /// <param name="password">ѕароль дл¤ ввода.</param>
    /// <param name="playerSpeed">—корость игрока.</param>
    public void ChangeObstacle(float timeInputZone, int keys, InputKeys[] password, float playerSpeed)
    {
        Zone zone = inputZone.GetComponent<Zone>();
        zone.CreateKey(keys, password);

        switch (zone.rightMove)
        {
            case ActionMove.None:
                playerPosXAfterObstacle = 0;
                break;
            case ActionMove.Right:
                playerPosXAfterObstacle = 3;
                break;
            case ActionMove.Left:
                playerPosXAfterObstacle = -3;
                break;
        }

        inputZone.transform.localScale = new Vector3(inputZone.transform.localScale.x, inputZone.transform.localScale.y, keys * timeInputZone * playerSpeed);
        inputZone.transform.localPosition = new Vector3(0,0, inputZone.transform.localScale.z/2f);

        cubes.transform.localPosition = new Vector3(0, 0, inputZone.transform.localScale.z + 10);
        lengthObstacle.transform.localPosition = new Vector3(0, 0, cubes.transform.localPosition.z + 2.5f);
    }
}