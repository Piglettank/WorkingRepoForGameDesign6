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

    //private void HighFiveAction()
    //{
    //    if (Dudes.DudeOne.transform.position == Dudes.LineOne.transform.position)
    //    {
    //        if (HighFiveTrust(trust) == 0)
    //        {
    //            animator.SetBool("mood", true);
    //        }
    //    }
    //}

    public int HighFiveTrust(int t)
    {
        if (trust == 0)
        {
            // MAKE NEUTRAL FACE
            // 
        }
        if (trust == 1)
        {
            // MAKE HAPPY FACE
        }
        if (trust == -1)
        {
            // MAKE SAD FACE
        }

        trust = t;

        return t;
    }

    void Update()
    {
        HighFiveTrust(trust);
        //HighFiveAction();
    }
}
