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
        spawnPosition = new Vector3(5.449153f, 3.710996f, -9.673029f);
        EnemySpawned = false;
    }

    void Update()
    {

        if (!EnemySpawned && hudController.distance >= 10f)
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
