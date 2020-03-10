using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] zoneOnePosition;
    public Transform[] zoneTwoPosition;
    public Transform[] zoneThreePosition;

    public GameObject[] projectileToSpawn;
    public GameObject[] projectileToClone;

    public static int bulletCount = 0;

    private float actionComplete = 2f;
    private float bulletDestroyTimer = 0f;
    private float actionTimer = 0f;

    public float zoneTwoTimer = 1.5f;
    public float zoneThreeTimer = 3f;

    private bool hasBullet = true;

    private int blueFirstPower = 2;
    private int blueSecondPower = 4;
    private int blueThirdPower = 6;

    void Start()
    {
        projectileToClone = new GameObject[projectileToSpawn.Length];
    }

    void Shooting()
    {
        if (bulletCount < 1)
        {
            hasBullet = true;
        }
        else if (bulletCount >= 1)
        {
            hasBullet = false;
        }

        if (hasBullet)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                actionTimer += Time.deltaTime;
                Debug.Log(actionTimer);
            }

            if (Input.GetKeyUp(KeyCode.Space) && actionTimer < zoneTwoTimer)
            {
                for (int i = 0; i < projectileToSpawn.Length; i++)
                {
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneOnePosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    //projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneOnePosition[1].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    //projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneOnePosition[2].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    Debug.Log("ZONE 1 FIRED");
                    bulletCount++;
                    actionTimer = 0f;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneTwoTimer && actionTimer < zoneThreeTimer)
            {
                for (int i = 0; i < projectileToSpawn.Length; i++)
                {
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneTwoPosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    //projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneTwoPosition[1].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    //projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneTwoPosition[2].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    Debug.Log("ZONE 2 FIRED");
                    bulletCount++;
                    actionTimer = 0f;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneThreeTimer)
            {
                for (int i = 0; i < 1; i++)
                {
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneThreePosition[0].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    Debug.Log("Zone 3 FIRED");
                    bulletCount++;
                    actionTimer = 0f;
                }
            }
        }
    }

    void DestroyBullet()
    {
        if (bulletCount >= 1)
        {
            // STARTS THE TIMER
            bulletDestroyTimer += Time.deltaTime;

            // 2 SECONDS TO COMPLETION
            if (bulletDestroyTimer >= actionComplete)
            {
                for (int i = 0; i < projectileToClone.Length; i++)
                {
                    Destroy(projectileToClone[i]);
                }
                bulletCount = 0;
                bulletDestroyTimer = 0f;
            }
        }
    }

    void Update()
    {
        Shooting();
        DestroyBullet();
    }
}

