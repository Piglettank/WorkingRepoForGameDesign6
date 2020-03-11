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
        // MAKE RANGE ONE ACTIVE
        if (PlayerShooting.rangeIndicatorOne)
        {
            for (int i = 0; i < rangeOne.Length; i++)
            {
                rangeOne[i].SetActive(true);
                PlayerShooting.rangeIndicatorOne = false;
            }
        }
        // MAKE RANGE ONE DEACTIVE
        else
        {
            for (int i = 0; i < rangeOne.Length; i++)
            {
                rangeOne[i].SetActive(false);
            }
        }

        // MAKE RANGE TWO ACTIVE
        if (PlayerShooting.rangeIndicatorTwo)
        {
            for (int i = 0; i < rangeTwo.Length; i++)
            {
                rangeTwo[i].SetActive(true);
                PlayerShooting.rangeIndicatorTwo = false;
            }
        }
        // MAKE RANGE TWO DEACTIVE
        else
        {
            for (int i = 0; i < rangeTwo.Length; i++)
            {
                rangeTwo[i].SetActive(false);
            }
        }

        // MAKE RANGE THREE ACTIVE
        if (PlayerShooting.rangeIndicatorThree)
        {
            for (int i = 0; i < rangeThree.Length; i++)
            {
                rangeThree[i].SetActive(true);
                PlayerShooting.rangeIndicatorThree = false;
            }
        }
        // MAKE RANGE TWO DEACTIVE
        else
        {
            for (int i = 0; i < rangeThree.Length; i++)
            {
                rangeThree[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        RangeIndicator();
    }
}
