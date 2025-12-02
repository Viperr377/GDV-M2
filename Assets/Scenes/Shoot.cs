using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб шарика
    public Transform firePoint;     // Точка, откуда вылетает шар
    public float shootForce = 15f;  // Сила выстрела

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
        {
            Fire();
        }
    }

    void Fire()
    {
        // Создаём шар
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Получаем Rigidbody и добавляем силу по направлению firePoint
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * shootForce, ForceMode2D.Impulse);
    }
}
