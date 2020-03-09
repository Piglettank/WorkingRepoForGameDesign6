using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform shootingPosition;
    public GameObject[] projectileToSpawn;
    private GameObject[] projectileToClone;

    public static int bulletCount = 0;

    private int blueFirstPower = 2;
    private int blueSecondPower = 4;
    private int blueThirdPower = 6;

    void Start()
    {
        projectileToClone = new GameObject[projectileToSpawn.Length];
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletCount < 1)
        {
            //if (Bullet.bluePower < blueFirstPower)
            //{
            //    // SPAWNS FIRST BULLET
            //}
            //else if (Bullet.bluePower >= blueSecondPower && Bullet.bluePower < blueThirdPower)
            //{
            //    // SPAWNS SECOND BULLET
            //}
            //else if (Bullet.bluePower >= blueThirdPower)
            //{
            //    // SPAWNS THIRD BULLET
            //}
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
