using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDirector : MonoBehaviour
{
    public event System.Action OnEnemyDeath;

    public Player player;
    public Enemy enemy;
    public Transform playerSatellite;
    public FourEnemy four;
    public Boss boss;

    [SerializeField] int enemiesAlive = 0;
    int enemiesKilled = 0;
    int enemyNumberToSpawn = 1;

    public float timeBetweenEnemies = 5f;
    float timeOfNextEnemy = 0;
    public float spawnDistFromPlayer = 10;

    public float wallTime = 10;
    public float timeBetweenWalls = 30;
    bool spawnWalls = false;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnWalls();
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

            if (spawnWalls)
            {
                wallTime -= Time.deltaTime;
                if (wallTime < 0)
                {
                    //spawnWalls = false;
                    SpawnWalls();
                }
            }
        }
    }

    void SpawnEnemy()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        Vector3 spawnPos = player.transform.position + new Vector3(x, 0, z).normalized * spawnDistFromPlayer;

        Enemy copy;

        copy = Instantiate(enemy, spawnPos, Quaternion.identity);

        if (enemyNumberToSpawn == 2)
        {
            copy.Setup(playerSatellite, enemyNumberToSpawn);
        }
        else
        {
            copy.Setup(player.transform, enemyNumberToSpawn);
        }
        copy.OnDeath += EnemyDied;

        enemiesAlive++;
    }

    void EnemyDied()
    {
        OnEnemyDeath?.Invoke();

        enemiesAlive--;
        enemiesKilled++;

        if (enemyNumberToSpawn < 6)
        {
            int oldNum = enemyNumberToSpawn;
            enemyNumberToSpawn = (enemiesKilled / 10)+1;

            if(oldNum < enemyNumberToSpawn)
            {
                SpawnBoss();
            }

            if(enemyNumberToSpawn == 4)
            {
                spawnWalls = true;
            }
            if(enemyNumberToSpawn > 6)
            {
                enemyNumberToSpawn = 6;
            }
        }
        
    }

    void SpawnBoss()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        Vector3 spawnPos = player.transform.position + new Vector3(x, 0, z).normalized * spawnDistFromPlayer;

        Boss b = Instantiate(boss, spawnPos, Quaternion.identity);
        b.Setup(player.transform, enemyNumberToSpawn-1);

    }

    void SpawnWalls()
    {
        if (wallTime > 0)
            return;

        wallTime = timeBetweenWalls;

        int numWalls = 10;
        float spacing = 4;
        int direction = -1;

        // spawn to the left and right
        for (int j = 0; j < 2; j++)
        {

            for (int i = 0; i < numWalls; i++)
            {
                Vector3 spawnPos = player.transform.position + new Vector3(direction * spawnDistFromPlayer, 0, ((numWalls / 2) * spacing - (spacing * i)) + j * spacing * 0.5f);
                FourEnemy copy = Instantiate(four, spawnPos, Quaternion.identity);
                copy.WallMode(Vector3.left * direction, 10);
                copy.Setup(player.transform, 4);
            }
            direction *= -1;
        }
    }
}
