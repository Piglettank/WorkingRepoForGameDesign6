using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiersSpawner : MonoBehaviour
{
    public GameObject enemy;

    private float xPos;
    private float zPos;

    public static int enemyCount;
    private int maxEnemies = 1;

    private float skierMaxTimer;
    private float skierSpawnTimer;
    private float delay;



    void Start()
    {
        maxEnemies = 3;
        delay = 5f;
    }




    private void Update()
    {
        skierMaxTimer += Time.deltaTime;
        skierSpawnTimer += Time.deltaTime;

        if (skierSpawnTimer >= delay)
        {
            if (enemyCount < maxEnemies)
            {
                skierSpawnTimer = 0f;

                xPos = Random.Range(-15, 16);
                zPos = -55 + Random.Range(-7, 8);

                Instantiate(enemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyCount++;
                Debug.Log("enemyCount: " + enemyCount);
            }
        }

        if (skierMaxTimer >= 5)
        {
            skierMaxTimer = 0f;

            maxEnemies += 2;
            Debug.Log("maxEnemies added, equals: " + maxEnemies);

            if (delay > 3.5f)
            {
                delay--;
            }
        }
    }
}
