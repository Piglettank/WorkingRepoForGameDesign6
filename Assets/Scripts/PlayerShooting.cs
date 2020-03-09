using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform shootingPosition;
    public GameObject[] projectileToSpawn;
    private GameObject[] projectileToClone;

    public static int bulletCount = 0;

    void Start()
    {
        projectileToClone = new GameObject[projectileToSpawn.Length];
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletCount < 1)
        {
            // SPAWNS BULLETS AND INCREMENTS bulletCount
            for (int i = 0; i < projectileToSpawn.Length; i++)
            {
                projectileToClone[i] = Instantiate(projectileToSpawn[i], shootingPosition.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                bulletCount++;
            }
            Debug.Log("FIRED");
        }
    }

    void Update()
    {
        Shooting();
    }
}
