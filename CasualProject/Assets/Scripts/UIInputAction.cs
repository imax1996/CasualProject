using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputAction : MonoBehaviour
{
    [SerializeField] private GameObject _arrowImagePrefab;
    [SerializeField] private Player player;
    [SerializeField] private Transform _anchorArrow;
    private List<GameObject> _arrowPool;

    [SerializeField] private float _speedAnimation;

    private void Awake()
    {
        _arrowPool = new List<GameObject>();
        player.EnterZoneEvent += InputActionVisible;
        player.ExitZoneEvent += SetDisableArrow;
        player.GameOverEvent += SetDisableArrow;
    }

    private void InputActionVisible(InputAction[] inputActions)
    {
        while (_arrowPool.Count < inputActions.Length)
        {
            GameObject arrow = Instantiate(_arrowImagePrefab, _anchorArrow);
            arrow.SetActive(false);
            _arrowPool.Add(arrow);
        }

        for (int i = 0; i < inputActions.Length; i++)
        {
            _arrowPool[i].SetActive(true);
            switch (inputActions[i])
            {
                case InputAction.Left:
                    _arrowPool[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case InputAction.Down:
                    _arrowPool[i].transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case InputAction.Right:
                    _arrowPool[i].transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case InputAction.Up:
                    _arrowPool[i].transform.rotation = Quaternion.Euler(0, 0, 270);
                    break;
            }
        }
    }

    private void SetDisableArrow()
    {
        foreach (var arrow in _arrowPool)
        {
            arrow.SetActive(false);
            StopAllCoroutines();
            arrow.GetComponent<Image>().color = Color.white;
        }
    }

    public void WrongAnim(int numOfArrow)
    {
        StopAllCoroutines();
        for (int i = 0; i < numOfArrow; i++)
        {
            StartCoroutine(AnimArrow(_arrowPool[i].GetComponent<Image>(), false));
        }
    }

    public void RightAnim(int numOfArrow)
    {
        StartCoroutine(AnimArrow(_arrowPool[numOfArrow].GetComponent<Image>(),true));
    }

    private IEnumerator AnimArrow(Image arrow, bool isRight)
    {
        Color color1 = Color.white;
        Color color2 = Color.green;
        if (!isRight)
        {
            color1 = Color.red;
            color2 = Color.white;
        }
        float timeProgress = 0;
        float timeAnimation = 1 / _speedAnimation;
        while (timeProgress < timeAnimation)
        {
            arrow.color = Color.Lerp(color1, color2, timeProgress / timeAnimation);
            timeProgress += Time.deltaTime;
            yield return null;
        }
    }
}
