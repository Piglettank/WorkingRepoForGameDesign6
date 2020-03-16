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
    private Vector3 projectileScaleZoneThree;

    public static bool rangeIndicatorOne = false;
    public static bool rangeIndicatorTwo = false;
    public static bool rangeIndicatorThree = false;

    private int bulletCount = 1;

    public float projectileThreeScale = 1f;
    public float projectileScale = 0.5f;

    private float actionTimer = 0f;

    private float cooldownTimer = 0f;
    private float cooldownComplete = 1.5f;

    private float zoneTwoTimer = 1.5f;
    private float zoneThreeTimer = 3f;

    private bool hasBullet = true;
    private bool startCooldown = false;


    void Start()
    {
        projectileToSpawn.transform.localScale = new Vector3(1f, 1f, 1f);

        projectileToClone = new GameObject[3];

        projectileScaleChange = new Vector3(projectileScale, 0f, projectileScale);
        projectileScaleZoneThree = new Vector3(projectileThreeScale, 0f, projectileThreeScale);

        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Shooting()
    {
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
                hasBullet = false;
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
                hasBullet = false;
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
            }

            // ZONE THREE ATTACK
            if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= zoneThreeTimer)
            {
                hasBullet = false;
                startCooldown = true;
                PlayerMovement.canMove = false;

                playerAnimator.SetBool("isCharging", false);
                playerAnimator.SetBool("isThrowing", true);

                if (!HitIndicator.hasPowerUp)
                {
                    for (int i = 0; i < projectileToClone.Length; i++)
                    {
                        projectileToClone[i] = Instantiate(projectileToSpawn, zoneThreePosition[i].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                        projectileToClone[i].transform.localScale += projectileScaleZoneThree;
                    }
                }

                //INCREASES THE PROJECTILE SIZE WITH POWER UP
                if (HitIndicator.hasPowerUp)
                {
                    for (int j = 0; j < projectileToClone.Length; j++)
                    {
                        projectileToClone[j] = Instantiate(projectileToSpawn, zoneThreePosition[j].position, Quaternion.Euler(0, 0, 0)) as GameObject;
                        //Debug.Log("POWER UP");

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

            if (cooldownTimer >= cooldownComplete)
            {
                PlayerMovement.canMove = true;

                // PUT IDLE ANIMATION HERE

                hasBullet = true;
                actionTimer = 0f;
                cooldownTimer = 0f;
                startCooldown = false;
                bulletCount++;
            }
        }
    }

    void DestroyBullet()
    {
        if (bulletCount >= 1)
        {
            for (int i = 0; i < projectileToClone.Length; i++)
            {
                Destroy(projectileToClone[i]);
            }
            bulletCount = 0;
        }
    }
 
    void Update()
    {
        Shooting();
        DestroyBullet();
    }
}

