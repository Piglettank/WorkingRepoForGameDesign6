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

    public void TrustCalculator()
    {
        if (Dudes.isHighFiveGuy)
        {
            // NEUTRAL STATE
            if (trust == 0)
            {
                // PLAYER PRESS HIGH FIVE BUTTON
                if (PlayerNew.buttonHighFive)
                {
                    DudeHand.isHighFive = true;
                    Debug.Log(DudeHand.isHighFive + "isHighFive Button Press");
                    trust = trust + 1;
                    // PLAY SFX

                }
                // PLAYER PRESS FAKE OUT BUTTON
                if (PlayerNew.buttonFakeOut)
                {
                    DudeHand.isHighFive = true;
                    trust = trust - 1;
                    // PLAY SFX
                }
                // PLAYER IGNORES
                if (PlayerNew.ignore)
                {
                    DudeHand.isHighFive = true;
                    // PLAY SFX
                }
            }

            // HAPPY STATE
            else if (trust == 1)
            {
                // PLAYER PRESS HIGH FIVE BUTTON
                if (PlayerNew.buttonHighFive)
                {
                    DudeHand.isHighFive = true;
                    // PLAY SFX
                }
                // PLAYER PRESS FAKE OUT BUTTON
                if (PlayerNew.buttonFakeOut)
                {
                    DudeHand.isHighFive = true;
                    trust = trust - 1;
                    // PLAY SFX
                }
                // PLAYER IGNORES
                if (PlayerNew.ignore)
                {
                    DudeHand.isHighFive = true;
                    trust = trust - 1;
                    // PLAY SFX
                }
            }

            // SAD STATE
            else
            {
                // PLAYER PRESS HIGH FIVE BUTTON
                if (PlayerNew.buttonHighFive)
                {
                    DudeHand.isHighFive = true;
                    trust = trust + 2;
                    // PLAY SFX
                }
                // PLAYER PRESS FAKE OUT BUTTON
                if (PlayerNew.buttonFakeOut)
                {
                    DudeHand.isHighFive = true;
                    // PLAY SFX
                }
                // PLAYER IGNORES
                if (PlayerNew.ignore)
                {
                    DudeHand.isHighFive = true;
                    // PLAY SFX
                }
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
        // REACTION BOOL AFTER ANIMATION
        // SETS THIS TO TRUE

        // SET MOOD TO NEUTRAL
        if (trust == 0)
        {
            animator.SetInteger("mood", 0);
            // PLAY SFX
        }
        // SET MOOD TO HAPPY
        else if (trust == 1)
        {
            animator.SetInteger("mood", 1);
            // PLAY SFX
        }
        // SET MOOD TO SAD
        else
        {
            animator.SetInteger("mood", -1);
            // PLAY SFX
        }
    }

    void Update()
    {
        TrustCalculator();
        Reaction();
    }
}
