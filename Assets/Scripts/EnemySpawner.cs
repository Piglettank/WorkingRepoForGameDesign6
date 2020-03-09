using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float xPos; 
    public static int enemyCount;
    public int maxEnemies;
    private float skierTimer;
    private int minSpawnDelay;
    void Start()
    {
        maxEnemies = 4;

        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (enemyCount < maxEnemies)
        {
            xPos = Random.Range(-9, 7);

            Instantiate(enemy, new Vector3(xPos, 1, -50), Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(Random.Range(5,7 - minSpawnDelay));
        }
    }

    private void Update()
    {
        skierTimer += Time.deltaTime;

        if (skierTimer > 20f)
        {
            maxEnemies += 2;
            skierTimer = 0;

            if (minSpawnDelay < 3)
            {
                minSpawnDelay--;
            }
        }
    }
}
