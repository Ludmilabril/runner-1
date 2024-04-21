using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PowerUp : MonoBehaviour
{
    public float powerUpDuration = 5f; // Duración del efecto del PowerUp.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Controller_Player playerController = collision.gameObject.GetComponent<Controller_Player>();
            if (playerController != null)
            {
                playerController.Immunity(powerUpDuration); // Inicia el PowerUp de invulnerabilidad en el jugador.
            }
            Destroy(gameObject);
        }
    }
}
