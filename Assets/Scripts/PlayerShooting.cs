using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] players;

    private float actionTimer;

    public float shootingZoneTwo = 1.5f;
    public float shootingZoneThree = 3f;

    List<Vector3> playerPosition = new List<Vector3>();
    
    void Start()
    {
        playerPosition.Add(players[0].transform.localPosition);
        playerPosition.Add(players[1].transform.localPosition);
        playerPosition.Add(players[2].transform.localPosition);
    }

    void Shooting()
    {


        // THE LOAD UP
        if (Input.GetKey(KeyCode.Space))
        {
            actionTimer += Time.deltaTime;
            Debug.Log("" + (int)actionTimer);
        }
        // ZONE ONE
        if (Input.GetKeyUp(KeyCode.Space) && actionTimer < shootingZoneTwo)
        {
            //if (Physics.Raycast(weaponPosition, shootingDirection, range))
            //{
            //    // something was hit - kill it!
            //}
            Debug.Log("Zone 1 fired");
            actionTimer = 0f;
        }
        // ZONE TWO
        if (Input.GetKeyUp(KeyCode.Space) && actionTimer < shootingZoneThree && actionTimer >= shootingZoneTwo)
        {
            Debug.Log("Zone 2 fired");
            actionTimer = 0f;
        }
        // ZONE THREE
        if (Input.GetKeyUp(KeyCode.Space) && actionTimer >= shootingZoneThree)
        {
            Debug.Log("Zone 3 fired");
            actionTimer = 0f;
        }
    }

    void Update()
    {
        Shooting();

        Vector3 currentPlayerPosition;

        for (int i = 0; i < playerPosition.Count; i++)
        {
            currentPlayerPosition = transform.localPosition;
            Debug.Log(currentPlayerPosition);
        }
    }
}
