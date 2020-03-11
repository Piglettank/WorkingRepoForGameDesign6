using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeIndicator : MonoBehaviour
{
    public GameObject[] rangeOne;
    public GameObject[] rangeTwo;
    public GameObject[] rangeThree;

    void Start()
    {

    }

    void RangeIndicator()
    {
        if (PlayerShooting.rangeIndicatorOne)
        {
            for (int i = 0; i < rangeOne.Length; i++)
            {
                rangeOne[i].SetActive(true);
                PlayerShooting.rangeIndicatorOne = false;
                Debug.Log("RANGE 1 ACTIVE");
            }
        }
        else
        {
            for (int i = 0; i < rangeOne.Length; i++)
            {
                rangeOne[i].SetActive(false);
                Debug.Log("RANGE 1 DEACTIVATED");
            }
        }

        if (PlayerShooting.rangeIndicatorTwo)
        {
            for (int i = 0; i < rangeTwo.Length; i++)
            {
                rangeTwo[i].SetActive(true);
                PlayerShooting.rangeIndicatorTwo = false;
                Debug.Log("RANGE 2 ACTIVE");
            }
        }
        else
        {
            for (int i = 0; i < rangeTwo.Length; i++)
            {
                rangeTwo[i].SetActive(false);
                Debug.Log("RANGE 2 DEACTIVATED");
            }
        }

        if (PlayerShooting.rangeIndicatorThree)
        {
            for (int i = 0; i < rangeThree.Length; i++)
            {
                rangeThree[i].SetActive(true);
                PlayerShooting.rangeIndicatorThree = false;
                Debug.Log("RANGE 3 ACTIVE");
            }
        }
        else
        {
            for (int i = 0; i < rangeThree.Length; i++)
            {
                rangeThree[i].SetActive(false);
                Debug.Log("RANGE 3 DEACTIVATED");
            }
        }
    }

    void Update()
    {
        RangeIndicator();
    }
}
