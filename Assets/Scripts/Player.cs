using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject[] dots = new GameObject[3];
    public bool newDude = true;
    public bool waitingReaction = true;

    private int waiting = 0;
    private int dotCount = -1;


    IEnumerator DotsCo() //wait 1s before adding a new dot onto the scene 
    {
        for (int a = 0; a <= 3; ++a)
        {
            yield return new WaitForSeconds(1);
            waiting += 1;
            dotCount += 1;
        }
    }

    IEnumerator IgnoredCo()
    {
        yield return new WaitForSeconds(1);
        // change the reaction to IGNORED 
        Debug.Log("IGNORED");
    }

    public void Toggle()
    {
        waitingReaction = false;
    }

    void RemoveDots() //resets the dots that indicate waiting time for player's reaction 
    {
        for (int b = 0; b <= 2; ++b)
        {
            dots[b].SetActive(false);
        }

        StartCoroutine(ReactionCo());
    }

    IEnumerator ReactionCo()
    {
        yield return new WaitForSeconds(3);
        newDude = true;
        waiting = 0;
        StopReactionCo();
    }

    void StopReactionCo()
    {
        StopCoroutine(ReactionCo());
    }

    void FixedUpdate()
    {

        if (newDude == true) //initialise the process of player reaction 
        {
            StartCoroutine(DotsCo());
            newDude = false;
            waitingReaction = true;
            Debug.Log("how many times am i here");
        }


        if (waitingReaction == true) //if still waiting for player's reaction
        {
            if (waiting > 0) //if player has waited for at least 1 more second, add a new dot
            {
                if (dotCount <= 2)
                {
                    dots[dotCount].SetActive(true);
                }
            }
        }

        if (waitingReaction == true)
        {
            if (waiting >= 4) //if a player has waited for at least 3 seconds, react with IGNORED 
            {
                StopCoroutine(DotsCo());
                waitingReaction = false;
                RemoveDots();
                Debug.Log("dots done");

                StartCoroutine(ReactionCo());
                StartCoroutine(IgnoredCo()); 
                StopCoroutine(IgnoredCo());
            }
        }


        if (waitingReaction == false)
        {
            RemoveDots(); //reset the dots and coroutines 
        }

        Debug.Log("newDude: " + newDude);
        Debug.Log("waitingReaction: " + waitingReaction);
    } //Fixed Update
}
