using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Controller_Hud hudController;

    private Vector3 spawnPosition;
    private bool EnemySpawned;

    void Start()
    {
        spawnPosition = new Vector3(4.49f, 3.37f, -10.16f);
        EnemySpawned = false;
    }

    void Update()
    {

        if (!EnemySpawned && hudController.distance >= 13f)
        {
            SpawnEnemy();
            EnemySpawned = true;
           
        }
        
    }


    public void SpawnEnemy()
    {
        GameObject PwUp = Instantiate(Enemy, transform) as GameObject;
        PwUp.transform.localPosition = spawnPosition;
    }
}
