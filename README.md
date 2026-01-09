# GDV-M2
Concept: Clash Royale Peggle

Beschrijving

De speler schiet een magische spirit-orb van boven het speelveld. De orb stuitert tegen verschillende Clash Royale-geesten: fire spirit, ice spirit, heal spirit en electro spirit.
Bij elke aanraking ontlaadt de spirit zijn speciale effect (vonken, ijs, vuur of helende pulsen), waardoor de score stijgt en het energiemeter wordt gevuld.
Wanneer de orb in de ketel onderaan valt, eindigt de beurt. Hoe meer spirits je raakt, hoe voller de energiemeter wordt.

<img width="862" height="923" alt="image" src="https://github.com/user-attachments/assets/b8b7e50d-8a8c-4a00-ac8e-f7c61951e8fb" />



2.1 **Collisions & Forces**



![2025-12-02 12-35-43 - Trim (1)](https://github.com/user-attachments/assets/d498bb6d-017b-4666-a1c6-5ea7c721656a)


Aim
```
using UnityEngine;

public class Aim : MonoBehaviour
{
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 0f; 

        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(mouse);
        Vector3 dir = worldMouse - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}'
```
code om het pistool in de richting van de cursor te laten draaien





2.2 


![Анимация](https://github.com/user-attachments/assets/80805dc8-1361-4a6e-883f-b20dd0441032)

Shoot
```
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
```


3.2 - 3.3 ***Combo systeem en het verdwijnen van de Peggle***

![2 3](https://github.com/user-attachments/assets/21025323-ee53-4a22-91e3-1edf79e82fbb)



Score Manager
```

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    public static ScoreManager Instance;

    // Totale score
    public int score = 0;


    private void Awake()
    {
        // controleren of er al een ScoreManager bestaat
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // dit is nu de enige ScoreManager in de scene
        Instance = this;
    }

    // functie om punten toe te voegen
    public void AddScore(int amount)
    {
        score = score + amount;
        // debug voor testen
        Debug.Log("Score: " + score);
    }
}
```

Peggle
```

using UnityEngine;

public class Peggle : MonoBehaviour
{
    public int hitsToDestroy = 3;     // totaal aantal hits dat deze peg aankan
    public int pointsPerHit = 10;     // aantal punten dat ??n hit waard is


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // score toekennen
        ScoreManager.Instance.AddScore(pointsPerHit);

        // aftellen
        hitsToDestroy--;

        // check of de peg nu op is
        if (hitsToDestroy <= 0)
        {
            Destroy(gameObject, 0.25f);
        }
    }
}
```


