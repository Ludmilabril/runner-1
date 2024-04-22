using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Damage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet2"))
        {
            Destroy(gameObject);

        }
        
    }
}
