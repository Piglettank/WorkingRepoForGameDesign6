using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] zoneOnePosition;
    public Transform[] zoneTwoPosition;
    public Transform[] zoneThreePosition;

    public GameObject[] projectileToSpawn;
    private GameObject[] projectileToClone;

    public static int bulletCount = 0;

    private float actionTimer = 0f;
    private float zoneTwoTimer = 1.5f;
    private float zoneThreeTimer = 3f;

    private int blueFirstPower = 2;
    private int blueSecondPower = 4;
    private int blueThirdPower = 6;

    void Start()
    {
        projectileToClone = new GameObject[projectileToSpawn.Length];
    }

    void Shooting()
    {
        
        if (Input.GetKey(KeyCode.Space) && bulletCount < 1)
        {
            actionTimer += Time.time;
            Debug.Log(actionTimer);

            if (Input.GetKeyUp(KeyCode.Space) && actionTimer < zoneTwoTimer)
            {
                for (int i = 0; i < projectileToSpawn.Length; i++)
                {
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneOnePosition[0].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneOnePosition[1].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneOnePosition[2].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    bulletCount++;
                    Debug.Log("ZONE 1 FIRED");

                    actionTimer = 0f;
                }
            }

            else if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneTwoTimer || actionTimer < zoneThreeTimer)
            {
                for (int i = 0; i < projectileToSpawn.Length; i++)
                {
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneTwoPosition[0].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneTwoPosition[1].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneTwoPosition[2].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    bulletCount++;
                    Debug.Log("ZONE 2 FIRED");

                    actionTimer = 0f;
                }
            }

            else if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneThreeTimer)
            {
                for (int i = 0; i < projectileToSpawn.Length; i++)
                {
                    Debug.Log("Zone 3 FIRED");
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneThreePosition[0].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    bulletCount++;

                    actionTimer = 0f;
                }
            }
        }

        

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
    }

    void Update()
    {
        Shooting();
    }
}
