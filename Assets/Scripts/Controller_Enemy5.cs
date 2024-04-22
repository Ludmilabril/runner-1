using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Enemy5 : MonoBehaviour
{
    public Transform Player;
    public GameObject Bullet;
    public Transform locationBullet;
    public float Speed = 1f;
    public float Rango;
    public LayerMask CapaJugador;
    bool alerta;

    void Start()
    {
        Player = FindObjectOfType<Controller_Player>().transform;

    }

    void Update() // si el personaje esta dentro del rango del enemigo, comienza a disparar.
    {
        alerta = Physics.CheckSphere(transform.position, Rango, CapaJugador);
        if (alerta == true)
        {
            Invoke("Disparo", 1);

        }
    }


    void Disparo() 
    {
        Vector3 direccion_jugador = (Player.position - transform.position).normalized;

        GameObject Bala2;
        Bala2 = Instantiate(Bullet, locationBullet.position, locationBullet.rotation);

        Bala2.GetComponent<Rigidbody>().AddForce(direccion_jugador * Speed, ForceMode.Impulse);
        CancelInvoke("Disparo");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Rango);
    }

}
