using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void EatBananaAnimation()
    {
        if (Banana.isBananaEaten)
        {
            // PLAY ANIMATION
        }
    }

    void Update()
    {
        EatBananaAnimation();
    }
}
