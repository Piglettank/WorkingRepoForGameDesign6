using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiersSpawner : MonoBehaviour
{
    public GameObject[] skiers = new GameObject[4];
    int skierTypes = 0;
    int lastSkierType = 0;
    int sameTypeCount = 0;

    private float xPos;
    private float zPos;

    public static int enemyCount;
    private int maxSkiers = 1;

    private float skierMaxTimer;
    private float skierSpawnTimer;
    private float delay;



    void Start()
    {
        maxSkiers = 3;
        delay = 5f;
    }




    private void Update()
    {
        skierMaxTimer += Time.deltaTime;
        skierSpawnTimer += Time.deltaTime;

        if (skierSpawnTimer >= delay)
        {
            if (enemyCount < maxSkiers)
            {
                skierSpawnTimer = 0f;

                xPos = Random.Range(-15, 16);
                zPos = -55 + Random.Range(-7, 8);

                //RANDOMLY GENERATE A SKIER TYPE, CAN'T SPAWN THE SAME TYPE 3 TIMES IN A ROW 
                do
                {
                    skierTypes = Random.Range(0, 4);

                    if (skierTypes == lastSkierType) sameTypeCount++;
                    else sameTypeCount = 0;
                } while (sameTypeCount > 3);

                lastSkierType = skierTypes;

                //SPAWN A SKIER
                Instantiate(skiers[skierTypes], new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyCount++;
            }
        }

        if (skierMaxTimer >= 5)
        {
            skierMaxTimer = 0f;

            maxSkiers += 2;

            if (delay > 3.5f)
            {
                delay--;
            }
        }
    }
}
