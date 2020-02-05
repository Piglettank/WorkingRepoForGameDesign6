using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    public GameObject[] dots = new GameObject[3];
    public bool newDude = true;

    private int dotCount; 
    private bool wait;
    private float currentTime = 0;
    static float addedTime = 3;

    IEnumerator DotsCo()
    {
        for (int a = 0; a <= 4; ++a)
        {
            yield return new WaitForSeconds(1f); 
            dotCount += 1;
            Debug.Log("dotCount: " + dotCount);
        }
    }

    IEnumerator WaitCo(float s, bool remove)
    {
        yield return new WaitForSeconds(s);
        if (remove == true) newDude = true;
    }

    public void Toggle()
    {
        wait = false;
    }

    public void Resett()
    {
        for (int b = 0; b <= 2; ++b)
        {
            dots[b].SetActive(false);
        }

        StopCoroutine(DotsCo());
        StartCoroutine(WaitCo(2, true));
        StopCoroutine(WaitCo(2, true));
    }

    void Start()
    {
        wait = false;
        addedTime = 3;
        Time.timeScale = 1f;
        currentTime = Time.time;
        dotCount = -1;
    }

    void FixedUpdate()
    {
        currentTime = Time.time;

        if (newDude == true)
        {
            newDude = false;
            wait = true;
            StartCoroutine(DotsCo());
        }


        if (wait == true)
        {
            if (dotCount >= 0 && dotCount <= 2)
            {
                dots[dotCount].SetActive(true);
            }


            if (currentTime >= addedTime)
            {
                Debug.Log("dots done");
                wait = false;
                // remove dots

                StartCoroutine(WaitCo(1, false));
                StopCoroutine(WaitCo(1, false));
                Debug.Log("IGNORED");
                Resett(); 

                //IGNORED
            }

        }else if (wait == false)
        {
            Resett();

        }

    }
}
