using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnerLocations;
    public GameObject[] prefabsToSpawn;
    private GameObject[] prefabsToClone;

    void Start()
    {
        prefabsToClone = new GameObject[prefabsToSpawn.Length];
    }

    void Spawn()
    {
        // IF THERE'S LESS THAN 1 BANANA
        if (Banana.bananaCount < 1)
        {
            // CHECK prefabsToSpawn TO SEE WHICH TO SPAWN
            for (int i = 0; i < prefabsToSpawn.Length; i++)
            {
                // SPAWNING BANANA PREFAB
                prefabsToClone[i] = Instantiate(prefabsToSpawn[i], spawnerLocations[i].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                // bananaCount SET TO 1
                Banana.bananaCount = 1;
                Banana.isBananaEaten = false;
            }
        }
    }

    void Update()
    {
        Spawn();
    }
}
