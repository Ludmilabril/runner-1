using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Gun : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public Vector2 sensitivity;

    void Update()
    {
        // Disparar cuando se presiona el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }

    }

    void FireBullet()
    {
        // Instanciar la bala en el gameObject del arma
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

        // Obtener el rigidbody de la bala y aplicarle fuerza en la dirección hacia adelante
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletSpawnPoint.transform.forward * bulletSpeed;

        // Destruir la bala 
        Destroy(bullet, 1f);
    }

   
}
