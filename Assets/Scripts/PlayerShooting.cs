using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] zoneOnePosition;
    public Transform[] zoneTwoPosition;
    public Transform[] zoneThreePosition;

    public GameObject projectileToSpawn;
    private GameObject[] projectileToClone;

    private Animator playerAnimator;

    private Vector3 projectileScaleChange;

    public static bool rangeIndicatorOne = false;
    public static bool rangeIndicatorTwo = false;
    public static bool rangeIndicatorThree = false;

    public int bulletCount = 0;

    private float projectileScale = 0.5f;
    private float actionComplete = 2f;
    private float bulletDestroyTimer = 0f;
    private float actionTimer = 0f;

    private float cooldownTimer = 0f;
    public float cooldownComplete = 0.75f;

    public float zoneTwoTimer = 1.5f;
    public float zoneThreeTimer = 3f;

    private bool hasBullet = true;
    private bool startCooldown = false;


    void Start()
    {
        projectileToSpawn.transform.localScale = new Vector3(1f, 1f, 1f);

        projectileToClone = new GameObject[3];

        projectileScaleChange = new Vector3(projectileScale, 0f, projectileScale);

        playerAnimator = gameObject.GetComponent<Animator>();
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
                PlayerMovement.canMove = false;
                playerAnimator.SetBool("isCharging", true);

                // RANGE INDICATOR

                // ZONE 1 INDICATOR
                if (actionTimer < zoneTwoTimer)
                {
                    // INDICATOR ONE TRUE
                    rangeIndicatorOne = true;
                }
                // ZONE 2 INDICATOR
                else if (actionTimer >= zoneTwoTimer && actionTimer < zoneThreeTimer)
                {
                    // INDICATOR ONE FALSE
                    // INDICATOR TWO TRUE
                    rangeIndicatorOne = false;
                    rangeIndicatorTwo = true;
                }
                // ZONE 3 INDICATOR
                else if (actionTimer >= zoneThreeTimer)
                {
                    // INDICATOR TWO FALSE
                    // INDICATOR THREE TRUE
                    rangeIndicatorTwo = false;
                    rangeIndicatorThree = true;
                }
            }

            // ZONE ONE ATTACK
            if (Input.GetKeyUp(KeyCode.Space) && actionTimer < zoneTwoTimer)
            {
                startCooldown = true;
                PlayerMovement.canMove = false;

                playerAnimator.SetBool("isCharging", false);
                playerAnimator.SetBool("isThrowing", true);

                if (!HitIndicator.hasPowerUp)
                {
                    for (int i = 0; i < projectileToClone.Length; i++)
                    {
                        projectileToClone[i] = Instantiate(projectileToSpawn, zoneOnePosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                        Debug.Log(projectileToClone[i].transform.localScale);
                    }
                }

                //INCREASES THE PROJECTILE SIZE WITH POWER UP
                if (HitIndicator.hasPowerUp)
                {
                    for (int j = 0; j < projectileToClone.Length; j++)
                    {
                        projectileToClone[j] = Instantiate(projectileToSpawn, zoneOnePosition[j].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                        Debug.Log("POWER UP");

                    }
                    projectileToSpawn.transform.localScale += projectileScaleChange;
                    HitIndicator.hasPowerUp = false;
                    Debug.Log(projectileToSpawn.transform.localScale);
                }
            }

            // ZONE TWO ATTACK
            if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneTwoTimer && actionTimer < zoneThreeTimer)
            {
                startCooldown = true;
                PlayerMovement.canMove = false;

                playerAnimator.SetBool("isCharging", false);
                playerAnimator.SetBool("isThrowing", true);

                if (!HitIndicator.hasPowerUp)
                {
                    for (int i = 0; i < projectileToClone.Length; i++)
                    {
                        projectileToClone[i] = Instantiate(projectileToSpawn, zoneTwoPosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                        Debug.Log(projectileToClone[i].transform.localScale);
                    }
                }

                //INCREASES THE PROJECTILE SIZE WITH POWER UP
                if (HitIndicator.hasPowerUp)
                {
                    for (int j = 0; j < projectileToClone.Length; j++)
                    {
                        projectileToClone[j] = Instantiate(projectileToSpawn, zoneTwoPosition[j].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                        Debug.Log("POWER UP");

                    }
                    projectileToSpawn.transform.localScale += projectileScaleChange;
                    HitIndicator.hasPowerUp = false;
                    Debug.Log(projectileToSpawn.transform.localScale);
                }

                // ZONE THREE ATTACK
                if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneThreeTimer)
                {
                    startCooldown = true;
                    PlayerMovement.canMove = false;

                    playerAnimator.SetBool("isCharging", false);
                    playerAnimator.SetBool("isThrowing", true);

                    if (!HitIndicator.hasPowerUp)
                    {
                        for (int i = 0; i < projectileToClone.Length; i++)
                        {
                            projectileToClone[i] = Instantiate(projectileToSpawn, zoneThreePosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                            Debug.Log(projectileToClone[i].transform.localScale);
                        }
                    }

                    //INCREASES THE PROJECTILE SIZE WITH POWER UP
                    if (HitIndicator.hasPowerUp)
                    {
                        for (int j = 0; j < projectileToClone.Length; j++)
                        {
                            projectileToClone[j] = Instantiate(projectileToSpawn, zoneThreePosition[j].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                            Debug.Log("POWER UP");

                        }
                        projectileToSpawn.transform.localScale += projectileScaleChange;
                        HitIndicator.hasPowerUp = false;
                        Debug.Log(projectileToSpawn.transform.localScale);
                    }
                }
            }

            if (startCooldown)
            {
                cooldownTimer += Time.deltaTime;
                Debug.Log(cooldownTimer);

                if (cooldownTimer >= cooldownComplete)
                {
                    PlayerMovement.canMove = true;
                    bulletCount++;
                    actionTimer = 0f;
                    cooldownTimer = 0f;
                    startCooldown = false;
                    Debug.Log("bajs");
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

