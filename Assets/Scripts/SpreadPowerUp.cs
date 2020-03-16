using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadPowerUp : MonoBehaviour
{
    public Transform[] playerPosition;
    public Transform[] rangePositionOne = new Transform[3];
    public Transform[] rangePositionTwo = new Transform[3];
    public Transform[] rangeIndicator = new Transform[7];

    private Vector3[] scaleChange = new Vector3[3];
    private Vector3[] scaleRangeChangeOne = new Vector3[3];
    private Vector3[] scaleRangeChangeTwo = new Vector3[3];
    private Vector3 scaleIndicatorChange;

    public float spreadIncrease = 0.10f;

    private float spreadRangeIncreaseOne = 0.5f;
    private float spreadRangeIncreaseTwo = 0.25f;
    private float rangeIndicatorIncrease = 0.5f;

    void Start()
    {
        // JOAKIM CHARACTER
        scaleChange[0] = new Vector3(0f, spreadIncrease, 0f);
        // JOHAN CHARACTER
        scaleChange[1] = new Vector3(spreadIncrease, -spreadIncrease, 0f);
        // KRZESIMIR CHARACTER
        scaleChange[2] = new Vector3(-spreadIncrease, -spreadIncrease, 0f);

        // ZONE ONE CHANGE
        scaleRangeChangeOne[0] = new Vector3(0f, 0f, spreadRangeIncreaseOne);
        scaleRangeChangeOne[1] = new Vector3(spreadRangeIncreaseOne, 0f, -spreadRangeIncreaseOne);
        scaleRangeChangeOne[2] = new Vector3(-spreadRangeIncreaseOne, 0f, -spreadRangeIncreaseOne);

        // ZONE TWO CHANGE
        scaleRangeChangeTwo[0] = new Vector3(0f, 0f, spreadRangeIncreaseTwo);
        scaleRangeChangeTwo[1] = new Vector3(spreadRangeIncreaseTwo, 0f, -spreadRangeIncreaseTwo);
        scaleRangeChangeTwo[2] = new Vector3(-spreadRangeIncreaseTwo, 0f, -spreadRangeIncreaseTwo);

        // RANGE INDICATOR CHANGE
        scaleIndicatorChange = new Vector3(rangeIndicatorIncrease, 0f, rangeIndicatorIncrease);
    }

    void Spread()
    {
        // CHEAT CODE BUTTON F
        // GET SPREADPOWER
        if (Input.GetKeyDown(KeyCode.F))
        {
            HitIndicator.spreadPower++;
            HitIndicator.hasPowerUp = true;
            HitIndicator.rotationPower--;
        }

        // IF YOU HIT AN ENEMY YOU GET SPREAD POWER
        if (HitIndicator.spreadPower >= 1)
        {
            HitIndicator.spreadPower--;
            // INCREASE THE SPREAD FOR PLAYERS
            for (int i = 0; i < scaleChange.Length; i++)
            {
                playerPosition[i].transform.localPosition += scaleChange[i];
            }
            // INCREASE THE SPREAD FOR RANGE ONE
            for (int i = 0; i < rangePositionOne.Length; i++)
            {
                rangePositionOne[i].transform.localPosition += scaleRangeChangeOne[i];
            }
            // INCREASE THE SPREAD FOR RANGE TWO
            for (int i = 0; i < rangePositionTwo.Length; i++)
            {
                rangePositionTwo[i].transform.localPosition += scaleRangeChangeTwo[i];
            }
            // INCREASE SIZE OF RANGE INDICATOR
            for (int i = 0; i < rangeIndicator.Length; i++)
            {
                rangeIndicator[i].transform.localScale += scaleIndicatorChange;
            }
        }
    }

    void Update()
    {
        Spread();
        
    }
}
