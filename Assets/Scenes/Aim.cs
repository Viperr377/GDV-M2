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
}
