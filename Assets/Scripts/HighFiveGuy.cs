using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFiveGuy : MonoBehaviour
{
    private Animator animator;
    public int trust = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void TrustCalculator()
    {
        // NEUTRAL STATE
        if (trust == 0)
        {
            // if (Highfive)
            {
                //trust = trust + 1;
            }
            // if (FakeOut)
            {
                //trust = trust - 1;
            }
            // if (Wait)
            {
                
            }
        }

        // HAPPY STATE
        else if (trust == 1)
        {
            // if (HighFive)
            {

            }
            // if (FakeOut)
            {
                //trust = trust - 1;
            }
            // if (Wait)
            {
                //trust = trust - 1;
            }
        }

        // SAD STATE
        else
        {
            // if (HighFive)
            {
                //trust = trust + 2;
            }
            // if (FakeOut)
            {
                
            }
            // if (Wait)
            {

            }
        }

        // trust CANNOT BE MORE THAN 1 
        // trust CANNOT BE LESS THAN -1
        if (trust <= -2)
        {
            trust = -1;
        }
        if (trust >= 2)
        {
            trust = 1;
        }
    }

    void Reaction()
    {
        // SET MOOD TO NEUTRAL
        if (trust == 0)
        {
            animator.SetInteger("mood", 0);
        }
        // SET MOOD TO HAPPY
        else if (trust == 1)
        {
            animator.SetInteger("mood", 1);
        }
        // SET MOOD TO SAD
        else
        {
            animator.SetInteger("mood", -1);
        }
    }

    void Action()
    {
        //// if (HighFive)
        //{
        //    animator.SetBool("HighFive", true);
        //}
        //// if (FakeOut)
        //{
        //    animator.SetBool("HighFive", true);
        //}
        //// if (Wait)
        //{
        //    animator.SetBool("HighFive", true);
        //}
    }

    void Update()
    {
        TrustCalculator();
        Reaction();
        Action();
    }
}
