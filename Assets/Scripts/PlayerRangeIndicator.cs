using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeIndicator : MonoBehaviour
{
    public ParticleSystem[] rangeOne;
    public ParticleSystem[] rangeTwo;
    public ParticleSystem[] rangeThree;

    void Start()
    {
        rangeOne[0].GetComponent<ParticleSystem>();
        rangeOne[1].GetComponent<ParticleSystem>();
        rangeOne[2].GetComponent<ParticleSystem>();

        rangeTwo[0].GetComponent<ParticleSystem>();
        rangeTwo[1].GetComponent<ParticleSystem>();
        rangeTwo[2].GetComponent<ParticleSystem>();

        rangeThree[0].GetComponent<ParticleSystem>();
    }

    void RangeIndicator()
    {
        if (PlayerShooting.rangeIndicatorOne)
        {
            for (int i = 0; i < rangeOne.Length; i++)
            {
                rangeOne[i].Play();
                PlayerShooting.rangeIndicatorOne = false;
            }
            
        }

        if (PlayerShooting.rangeIndicatorTwo)
        {
            for (int i = 0; i < rangeTwo.Length; i++)
            {
                rangeTwo[i].Play();
                PlayerShooting.rangeIndicatorTwo = false;
            }
            
        }

        if (PlayerShooting.rangeIndicatorThree)
        {
            for (int i = 0; i < rangeThree.Length; i++)
            {
                rangeThree[i].Play();
                PlayerShooting.rangeIndicatorThree = false;
            }
            
        }
    }

    void Update()
    {
        RangeIndicator();
    }
}
