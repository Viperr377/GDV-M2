# GDV-M2
Concept: Clash Royale Peggle

Beschrijving

De speler schiet een magische spirit-orb van boven het speelveld. De orb stuitert tegen verschillende Clash Royale-geesten: fire spirit, ice spirit, heal spirit en electro spirit.
Bij elke aanraking ontlaadt de spirit zijn speciale effect (vonken, ijs, vuur of helende pulsen), waardoor de score stijgt en het energiemeter wordt gevuld.
Wanneer de orb in de ketel onderaan valt, eindigt de beurt. Hoe meer spirits je raakt, hoe voller de energiemeter wordt.

<img width="862" height="923" alt="image" src="https://github.com/user-attachments/assets/b8b7e50d-8a8c-4a00-ac8e-f7c61951e8fb" />



2.1 Collisions & Forces



![2025-12-02 12-35-43 - Trim (1)](https://github.com/user-attachments/assets/d498bb6d-017b-4666-a1c6-5ea7c721656a)

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

