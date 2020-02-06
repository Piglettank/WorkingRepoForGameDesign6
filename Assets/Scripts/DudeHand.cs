using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeHand : MonoBehaviour
{
    private Animator handAnimator;
    public GameObject dudeHand;

    public static bool isHighFive = false;
    public static bool isFakeOut = false;
    public static bool isIgnore = false;

    void Start()
    {
        handAnimator = GetComponent<Animator>();
    }

    void Action()
    {
        if (isHighFive)
        {
            handAnimator.SetBool("HighFive", true);
            isHighFive = false;
        }
        else if (isFakeOut)
        {
            handAnimator.SetBool("FakeOut", true);
            isFakeOut = false;
        }
        else if (isIgnore)
        {
            isIgnore = false;
        }
    }

    void Update()
    {
        Action();
    }
}
