using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public event System.Action AnimEndEvent;

    [SerializeField] private float _speedAnim;

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(IEFadeIn());
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(IEFadeOut());
    }

    private IEnumerator IEFadeOut()
    {
        Image image = GetComponent<Image>();
        gameObject.transform.localScale = Vector3.zero;
        image.color = new Color(1, 1, 1, 0);

        float process = 0;
        while (process <= 1)
        {
            gameObject.transform.localScale = Vector3.one * process * 3;
            image.color = new Color(1, 1, 1, process);
            process += Time.deltaTime;
            yield return null;
        }

        AnimEndEvent?.Invoke();
    }

    private IEnumerator IEFadeIn()
    {
        Image image = GetComponent<Image>();
        gameObject.transform.localScale = Vector3.one * 3;
        image.color = new Color(1, 1, 1, 1);

        float process = 0;
        while (process <= 1)
        {
            image.color = new Color(1, 1, 1, 1 - process);
            process += Time.deltaTime;
            yield return null;
        }
    }
}
