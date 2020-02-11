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

    private float highFiveFloat = 0f;
    private float fakeOutFloat = 0f;
    private float ignoreFloat = 0f;

    void Start()
    {
        handAnimator = GetComponent<Animator>();
    }

    public void Action()
    {
        if (isHighFive)
        {
            handAnimator.SetFloat("HighFive", 60);
            isHighFive = false;
        }
        else if (isFakeOut)
        {
            handAnimator.SetFloat("FakeOut", 60);
            isFakeOut = false;
        }
        else if (isIgnore)
        {
            isIgnore = false;
        }
    }

    public void ResetAnimation()
    {
        handAnimator.SetFloat("HighFive", 0);
        handAnimator.SetFloat("FakeOut", 0);
    }

    void Update()
    {
        Action();
        //if (handAnimator.GetFloat("HighFive") > 0)
        Debug.Log(isHighFive + " isHighFive");
            highFiveFloat = handAnimator.GetFloat("HighFive");
            highFiveFloat--;
            handAnimator.SetFloat("HighFive", highFiveFloat);            
            
            fakeOutFloat = handAnimator.GetFloat("FakeOut");
            fakeOutFloat--;
            handAnimator.SetFloat("FakeOut", fakeOutFloat);
        

    }
}
