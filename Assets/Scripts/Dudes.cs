using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dudes : MonoBehaviour
{
    private Animator animatorHighFiveGuy;
    private Animator animatorShyGuy;
    private Animator animatorToughGuy;

    public GameObject DudeOne, DudeTwo, DudeThree;
    public GameObject LineOne, LineTwo, LineThree;

    public List<GameObject> DudeList;
    public List<GameObject> LineListOne;

    public int linePosition = 0;

    //public int highfiveTrust = 0;
    //public int shyguyTrust = 0;
    //public int toughguyTrust = 0;
    //public int trust = 0;

    public static bool hasFived = false;

    void Start()
    {
        DudeList = new List<GameObject>();
        DudeList.Add(DudeOne);
        DudeList.Add(DudeTwo);
        DudeList.Add(DudeThree);

        animatorHighFiveGuy = DudeOne.GetComponent<Animator>();
        animatorShyGuy = DudeTwo.GetComponent<Animator>();
        animatorToughGuy = DudeThree.GetComponent<Animator>();
    }

    //void Mood()
    //{
    //    if (highfiveTrust == 0)
    //    {
    //        animatorHighFiveGuy.SetInteger("mood", 0);
    //    }
    //    else if (trust == 1)
    //    {
    //        animatorHighFiveGuy.SetInteger("mood", 1);
    //        animatorShyGuy.SetInteger("mood", 1);
    //        animatorToughGuy.SetInteger("mood", 1);
    //    }
    //    else if (trust == -1)
    //    {
    //        animatorHighFiveGuy.SetInteger("mood", -1);
    //        animatorShyGuy.SetInteger("mood", -1);
    //        animatorToughGuy.SetInteger("mood", -1);
    //    }
    //}

    void MoveLine()
    {
        // WHEN PRESS SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // linePosition INCREMENTS BY 1
            linePosition++;

            // LINEPOSITION CANNOT BE MORE THAN 3
            if (linePosition == 3)
            {
                linePosition = 0;
            }

            // linePosition 0
            // HIGH FIVE GUY IN FRONT
            if (linePosition == 0)
            {
                LineListOne.Clear();
                LineListOne.Add(LineOne);
                LineListOne.Add(LineTwo);
                LineListOne.Add(LineThree);
                hasFived = true;
                Debug.Log(hasFived);

                //if (highfiveTrust == 0)
                //{
                //    animatorHighFiveGuy.SetBool("mood", true);
                //}

                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListOne
                    DudeList[i].transform.position = LineListOne[i].transform.position;
                }
            }

            // linePosition 1
            // SHY GUY IN FRONT
            else if (linePosition == 1)
            {
                LineListOne.Clear();
                LineListOne.Add(LineThree);
                LineListOne.Add(LineOne);
                LineListOne.Add(LineTwo);

                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListTwo
                    DudeList[i].transform.position = LineListOne[i].transform.position;
                }
            }

            // linePosition 2
            // TOUGH GUY IN FRONT
            else if (linePosition == 2)
            {
                LineListOne.Clear();
                LineListOne.Add(LineTwo);
                LineListOne.Add(LineThree);
                LineListOne.Add(LineOne);

                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListThree
                    DudeList[i].transform.position = LineListOne[i].transform.position;  
                }
            }
        }
    }

    void Update()
    {
        MoveLine();
    }
}
