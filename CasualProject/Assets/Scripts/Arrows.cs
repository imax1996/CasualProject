using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject _arrowPrefab;
    public List<GameObject> ArrowsList;

    private void Awake()
    {
        ArrowsList = new List<GameObject>();
    }

    public void Activate(InputZoneData.Direction[] directions)
    {
        while(directions.Length > ArrowsList.Count)
        {
            GameObject arrow = Instantiate(_arrowPrefab, gameObject.transform);
            ArrowsList.Add(arrow);
        }

        for (int i = 0; i < directions.Length; i++)
        {
            ArrowsList[i].transform.rotation = Quaternion.Euler(RotateArrow(directions[i]));
            ArrowsList[i].SetActive(true);
        }
    }

    public void Disactivate()
    {
        foreach (var arrow in ArrowsList)
        {
            arrow.SetActive(false);
        }
    }

    private Vector3 RotateArrow(InputZoneData.Direction direction)
    {
        float rotZ = 0;

        switch (direction)
        {
            case InputZoneData.Direction.Right:
                rotZ = 180;
                break;
            case InputZoneData.Direction.Up:
                rotZ = 270;
                break;
            case InputZoneData.Direction.Left:
                rotZ = 0;
                break;
            case InputZoneData.Direction.Down:
                rotZ = 90;
                break;
        }

        return new Vector3(0, 0, rotZ);
    }
}
