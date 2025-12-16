using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    [SerializeField] private float lineSpeed = 10f;
    private LineRenderer _line;

    private bool _lineActive = false;
    private float _pressTimer = 0f;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        if (_line == null)
        {
            Debug.LogWarning("LineRenderer не найден!");
            return;
        }

        if (_line.positionCount < 2)
            _line.positionCount = 2;

        _line.useWorldSpace = false;

        _line.SetPosition(0, Vector3.zero);
        _line.SetPosition(1, Vector3.zero);
    }

    void Update()
    {
        HandleShot();
    }

    private void HandleShot()
    {
        if (_line == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0f;
            _lineActive = true;
        }
        if (_lineActive)
        {
            _pressTimer += Time.deltaTime;
            _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }

        if (Input.GetMouseButtonUp(0))
        {
            float shotPower = _pressTimer * lineSpeed;

            Shoot(shotPower);

            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }
    }

    void Shoot(float power)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.right * power, ForceMode2D.Impulse);
        }
    }
}

