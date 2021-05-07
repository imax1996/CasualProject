using UnityEngine;

/// <summary>
/// Класс, определяющий движение куба (игрока).
/// </summary>
public class CubeMove : MonoBehaviour
{
    [Header("Set in Inspector: CubeMove")]
    public float speed = 10;
    public float pointToBackZ = 100;

    [HideInInspector] public bool   nextLevel;
    private Rigidbody               rb;
    private float                   offsetX;
    private float                   offset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;

        if (offset > 0)
        {
            float _offsetX = offsetX * Time.fixedDeltaTime * speed/2;
            Vector3 newPos;
            if (Mathf.Abs(_offsetX) > Mathf.Abs(offset))
            {
                newPos = transform.position + Vector3.right * offset * Mathf.Sign(offsetX);
            }
            else
            {
                newPos = transform.position + Vector3.right * _offsetX;
            }
            offset -= Mathf.Abs(_offsetX);
            rb.MovePosition(newPos);
        }
    }

    private void LateUpdate()
    {
        if (transform.position.z >= pointToBackZ && nextLevel)
        {
            nextLevel = false;
            StartCoroutine(UIMenu.S.NextLevel());
        }
    }

    /// <summary>
    /// Выполнить при столкновении с препятствием (gameover).
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        gameObject.SetActive(false);
        UIMenu.S.GameOver();
    }

    /// <summary>
    /// Выполнить при входе в зону ввода.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        InputPassword.S.enabled = true;
        InputPassword.S.GetPassword(other.GetComponent<Zone>());
        UIPassword.S.ShowKey(other.GetComponent<Zone>().keys);
    }

    /// <summary>
    /// Выполнить при выходе из зоны ввода.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        switch (InputPassword.S.Move())
        {
            case ActionMove.Right:
                offsetX = 3;
                offset = 3;
                break;
            case ActionMove.Left:
                offsetX = -3;
                offset = 3;
                break;
        }
    }
}