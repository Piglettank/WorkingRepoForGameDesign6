using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadPowerUp : MonoBehaviour
{
    public Transform[] playerPosition;

    void Start()
    {
        
    }

    void Spread()
    {
        if (HitIndicator.spreadPower == 1)
        {
            // WORKS BUT MAYBE DO IT LIKE A BOOL
            playerPosition[0].transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Debug.Log("Increase SPREAD");
            HitIndicator.spreadPower = 2;
        }
    }

    void Update()
    {
        Spread();
    }
}
