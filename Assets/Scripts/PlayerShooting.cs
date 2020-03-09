using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform shootingPosition;
    public Rigidbody projectile;

    private int bulletCount = 0;

    void Start()
    {
        
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, shootingPosition.position, Quaternion.Euler(0, 0, 0));
            Debug.Log("FIRED");
        }
    }

    void Update()
    {
        Shooting();
    }
}
