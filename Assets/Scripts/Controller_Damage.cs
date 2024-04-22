using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Damage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Destruir si el enemigo colisiona con la bala del personaje.
    {
        if (other.CompareTag("Bullet2")) 
        {
            Destroy(gameObject);

        }
        
    }
}
