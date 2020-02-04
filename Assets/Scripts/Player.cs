using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject[] dots = new GameObject[3];
    public bool newDude = true;

    private int waiting = 0;
    private int dotCount = -1;



    IEnumerator WaitingCo()
    {
        for (int a = 0; a <= 2; ++a)
        {
            yield return new WaitForSeconds(1);
            waiting += 1;
            dotCount += 1;
            Debug.Log("1s more");
            Debug.Log("a: " + a);
            Debug.Log("waiting: " + waiting);
        }
    }

    IEnumerator EndCo()
    {
            yield return new WaitForSeconds(1);
            Debug.Log("IGNORED");
    }

    void FixedUpdate()
    {

        if (newDude == true)
        {
            StartCoroutine(WaitingCo());
            newDude = false;
        }

        if (waiting > 0)
        {
            dots[dotCount].SetActive(true);
        }

        if (waiting >= 3)
        {
            StopCoroutine(WaitingCo());
            Debug.Log("dots done"); 
            
            StartCoroutine(EndCo());
            StopCoroutine(EndCo()); 
        }
    }
}
