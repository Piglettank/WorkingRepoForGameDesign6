using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohansShittyAnimationScript : MonoBehaviour
{
    public GameObject circle;
    Animator playerAnimator;

    void Start()
    {
        //Get Animator
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Set joakimRotation to the z rotation of the Gucci Gang
        playerAnimator.SetFloat("joakimRotation", 360 - circle.transform.eulerAngles.y);
        Debug.Log(circle.transform.rotation.z);
    }
}
