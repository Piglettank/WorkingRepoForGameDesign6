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
        if (Banana.bananaCount < 1)
        {
            for (int i = 0; i < prefabsToSpawn.Length; i++)
            {
                prefabsToClone[i] = Instantiate(prefabsToSpawn[i], spawnerLocations[i].transform.position, Quaternion.Euler(0, 0, 90)) as GameObject;
                Banana.bananaCount = 1;
            }
        }
    }

    void Update()
    {
        Spawn();
    }
}
