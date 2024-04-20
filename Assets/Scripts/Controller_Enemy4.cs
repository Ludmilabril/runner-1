using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Enemy4 : MonoBehaviour
{
    public float speed = 15f; // Velocidad.
    public float MoveY = 1f; // Intervalo de tiempo entre cambios de dirección.
    private float Ytimer; // Temporizador.

    void Start()
    {
        Ytimer = MoveY;
    }

    void Update()
    {
        // Actualizar el temporizador vertical.
        Ytimer -= Time.deltaTime;

        // Si llega a cero, cambia la dirección y reinicia el temporizador.
        if (Ytimer <= 0f)
        {
            Ytimer = MoveY;
            ChangeDirection();
        }

        // Mover al enemigo.
        Move();
    }

    void Move()
    {
        // Mover hacia arriba o hacia abajo.
        if (transform.up.y > 0) 
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else 
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
    }

    void ChangeDirection()
    {
        // Cambiar la dirección.
        transform.up = -transform.up;
    }

}