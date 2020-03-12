using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiersSpawner : MonoBehaviour
{
    public GameObject enemy;

    private float xPos;

    public static int enemyCount;
    public int maxEnemies;

    private float skierTimer;
    private int minSpawnDelay;



    void Start()
    {
        maxEnemies = 8;

        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (enemyCount < maxEnemies)
        {
            xPos = Random.Range(-15, 16);

            Instantiate(enemy, new Vector3(xPos, 2, -55 + Random.Range(0,5)), Quaternion.identity);
            enemyCount++;
            Debug.Log("enemyCount = " + enemyCount);
            yield return new WaitForSeconds(2);
        }
    }

    private void Update()
    {
        skierTimer += Time.deltaTime;

        if (skierTimer >= 10f)
        {
            maxEnemies += 2;
            skierTimer = 0f;
            Debug.Log("maxEnemies = " + maxEnemies);

            if (minSpawnDelay > 3.5f)
            {
                minSpawnDelay--;
                Debug.Log("minSpawnDelay = " + minSpawnDelay);
            }
        }
    }
}
