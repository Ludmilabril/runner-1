using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_spawn : MonoBehaviour
{
    public GameObject PowerUp;
    public Controller_Hud hudController; 

    private Vector3 spawnPosition;
    private bool powerUpSpawned;

    void Start() //Instanciar donde se mostrara el power up en el juego.
    {
        spawnPosition = new Vector3(-2.55f, 0.86f, -3.11f);
        powerUpSpawned = false;
    }

    void Update()//Identificar si se cumple con lo requerido para spawnear el power up.
    {
        
        if (!powerUpSpawned && hudController.distance >= 5f )
        {
            SpawnPowerUP();
            powerUpSpawned = true; 
        }
       
    }
    
   
    public void SpawnPowerUP() 
    {
        GameObject PwUp = Instantiate(PowerUp, transform) as GameObject;
        PwUp.transform.localPosition = spawnPosition;
    }
}
