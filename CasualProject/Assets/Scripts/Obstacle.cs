using UnityEngine;

public class Obstacle : MonoBehaviour {
    [Header("Set in Inspector: ObstacleCreator")]
    public GameObject obstacle;
    public GameObject inputZone;
    public GameObject cubes;
    public GameObject lengthObstacle;
    public float playerPosXAfterObstacle;

    public void Change(float timeInputZone, int keys, InputKeys[] password, float playerSpeed) {
        Zone zone = inputZone.GetComponent<Zone>();
        zone.CreateKey(keys, password);

        inputZone.transform.localScale = new Vector3(inputZone.transform.localScale.x, inputZone.transform.localScale.y, keys * timeInputZone * playerSpeed);
        inputZone.transform.localPosition = new Vector3(0,0, inputZone.transform.localScale.z/2f);

        cubes.transform.localPosition = new Vector3(0, 0, inputZone.transform.localScale.z + 10);
        lengthObstacle.transform.localPosition = new Vector3(0, 0, cubes.transform.localPosition.z + 2.5f);
    }
}