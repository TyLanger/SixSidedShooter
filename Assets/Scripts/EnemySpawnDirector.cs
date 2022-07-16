using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDirector : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] int enemiesAlive = 0;
    int enemiesKilled = 0;
    int enemyNumberToSpawn = 1;

    public float timeBetweenEnemies = 5f;
    float timeOfNextEnemy = 0;
    public float spawnDistFromPlayer = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.instance.isPaused)
        {
            if (Time.time > timeOfNextEnemy)
            {
                SpawnEnemy();
                timeOfNextEnemy = Time.time + timeBetweenEnemies;
            }
        }
    }

    void SpawnEnemy()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        Vector3 spawnPos = player.transform.position + new Vector3(x, 0, z).normalized*spawnDistFromPlayer;

        var copy = Instantiate(enemy, spawnPos, Quaternion.identity);
        copy.Setup(player.transform, enemyNumberToSpawn);
        copy.OnDeath += EnemyDied;

        enemiesAlive++;
    }

    void EnemyDied()
    {
        enemiesAlive--;
        enemiesKilled++;

        if (enemyNumberToSpawn < 6)
        {
            enemyNumberToSpawn = (enemiesKilled / 10)+1;
            if(enemyNumberToSpawn > 6)
            {
                enemyNumberToSpawn = 6;
            }
        }
        
    }
}
