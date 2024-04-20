using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies; // Lista que que contiene a los distintos tipos de enemigos.
    public GameObject instantiatePos; // Indica la posición en donde se instanciaran los enemigos.
    public float respawningTimer; // Tiempo que determina cuando apareceran los enemigos.
    private float time = 0; // Determina el tiempo transcurrido para cambiar la velocidad de los enemigos.

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2; // Velocidad inicial de los enemigos.
    }

    void Update()
    {
        SpawnEnemies(); 
        ChangeVelocity();
    }

    private void ChangeVelocity() // Esta función cambia la velocidad de los enemigos a lo largo de los 45s.
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnEnemies() // Esta función determina cuando aparecen los enemigos.
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(2, 6);
        }
    }
}
