using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
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
            Debug.LogWarning("LineRenderer.");
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.right * bulletForce);
        }
        else
        {
            Debug.LogWarning("У пули нет Rigidbody2D!");
        }
    }
    private void HandleShot()
    {
        if (_line == null) return; 

        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0f;
            _lineActive = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }

        if (_lineActive)
        {
            _pressTimer += Time.deltaTime;
            _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }
    }
}

