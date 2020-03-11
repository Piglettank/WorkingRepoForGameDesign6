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

    public static bool rangeIndicatorOne = false;
    public static bool rangeIndicatorTwo = false;
    public static bool rangeIndicatorThree = false;

    public int bulletCount = 0;

    private float actionComplete = 2f;
    private float bulletDestroyTimer = 0f;
    private float actionTimer = 0f;

    public float zoneTwoTimer = 1.5f;
    public float zoneThreeTimer = 3f;

    private bool hasBullet = true;

    void Start()
    {
        projectileToClone = new GameObject[projectileToSpawn.Length];
    }

    void Shooting()
    {
        // CHECKS IF PLAYER CAN SHOOT OR NOT
        if (bulletCount < 1)
        {
            hasBullet = true;
        }
        else
        {
            hasBullet = false;
        }

        // IF THE PLAYER CAN SHOOT
        if (hasBullet)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // STARTS TIMER WHEN SPACE IS PRESSED
                actionTimer += Time.deltaTime;

                // RANGE INDICATOR

                // ZONE 1 INDICATOR
                if (actionTimer < zoneTwoTimer)
                {
                    // INDICATOR ONE TRUE
                    rangeIndicatorOne = true;

                    Debug.Log("ZONE ONE LOAD UP");
                }
                // ZONE 2 INDICATOR
                else if (actionTimer >= zoneTwoTimer && actionTimer < zoneThreeTimer)
                {
                    // INDICATOR ONE FALSE
                    // INDICATOR TWO TRUE
                    rangeIndicatorOne = false;
                    rangeIndicatorTwo = true;

                    Debug.Log("ZONE TWO LOAD UP");
                }
                // ZONE 3 INDICATOR
                else if (actionTimer >= zoneThreeTimer)
                {
                    // INDICATOR TWO FALSE
                    // INDICATOR THREE TRUE
                    rangeIndicatorTwo = false;
                    rangeIndicatorThree = true;

                    Debug.Log("ZONE THREE LOAD UP");
                }
            }

            // ZONE ONE ATTACK
            if (Input.GetKeyUp(KeyCode.Space) && actionTimer < zoneTwoTimer)
            {
                for (int i = 0; i < projectileToSpawn.Length; i++)
                {
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneOnePosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    Debug.Log("ZONE 1 FIRED");
                    bulletCount++;
                    actionTimer = 0f;
                }
            }

            // ZONE TWO ATTACK
            if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneTwoTimer && actionTimer < zoneThreeTimer)
            {
                for (int i = 0; i < projectileToSpawn.Length; i++)
                {
                    projectileToClone[i] = Instantiate(projectileToSpawn[i], zoneTwoPosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    Debug.Log("ZONE 2 FIRED");
                    bulletCount++;
                    actionTimer = 0f;
                }
            }

            // ZONE THREE ATTACK
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

            // 2 SECONDS UNTIL DESTROYED
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

