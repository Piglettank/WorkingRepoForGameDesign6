using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    public GameObject[] dots = new GameObject[3];
    public bool newDude = true;
    public bool reacted = false;
    public string reaction;

    private int dotCount; 
    private bool wait;
    private float currentTime = 0;
    static float compareTime = 0;
    private bool invoke = true;
    private bool remove = false;

    IEnumerator DotsCo()
    {
        for (int a = 0; a <= 4; ++a)
        {
            yield return new WaitForSeconds(1f); 
            dotCount += 1;
        }
    }

    IEnumerator WaitCo(float s)
    {
        yield return new WaitForSeconds(s);
    }

    public void NewDot()
    {
        if (remove == true)
        {
            remove = false;
            return;
        }

        dotCount += 1;
        invoke = true;
    }

    public void ToggleHighFive()
    {
        newDude = true;
        reacted = true;
        reaction = "HighFive";
    }

    public void ToggleFakeOut()
    {
        newDude = true;
        reacted = true;
        reaction = "FakeOut";
    }

    public void Resett()
    {
        CancelInvoke();

        for (int b = 0; b <= 2; ++b)
        {
            dots[b].SetActive(false);
        }
    }

    void Start()
    {
        wait = false;
        Time.timeScale = 1f;
        currentTime = Time.time;
        dotCount = -1;
    }

    void FixedUpdate()
    {
        currentTime = Time.time;


        if (reacted == true)
        {
            Debug.Log("REACTED: " + reaction);
        }


        if (newDude == true)
        {
            Resett();
            //remove = true;
            newDude = false;
            wait = true;
            reacted = false;
            compareTime = Time.time + 4.5f;
        }


        if (wait == true)
        {
            if (dotCount >= 0 && dotCount <= 2)
            {
                dots[dotCount].SetActive(true);
            }

            if (invoke == true)
            {
                Debug.Log("invoke");

                Invoke("NewDot", 1f);
                invoke = false;
            }


            if (currentTime >= compareTime)
            {
                currentTime = Time.time;

                wait = false;
                Resett();

                reaction = "Ignored"; 
                Debug.Log("IGNORED");
                return; 
            }

        }else if (wait == false)
        {
            Resett();
        }
    }
}
