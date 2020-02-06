using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dudes : MonoBehaviour
{
    public GameObject DudeOne, DudeTwo, DudeThree;
    public GameObject LineOne, LineTwo, LineThree;

    public List<GameObject> DudeList;
    public List<GameObject> LineList;

    public int linePosition = 0;

    public static bool isHighFiveGuy = false;
    public static bool isShyGuy = false;
    public static bool isToughGuy = false;

    void Start()
    {
        DudeList = new List<GameObject>();
        DudeList.Add(DudeOne);
        DudeList.Add(DudeTwo);
        DudeList.Add(DudeThree);

        LineList = new List<GameObject>();
        LineList.Add(LineOne);
        LineList.Add(LineTwo);
        LineList.Add(LineThree);

        isHighFiveGuy = true;
        //linePosition = -1;
    }

    void MoveLine()
    {
        // WHEN PRESS SPACE
        // WHEN COOLDOWN BOOL IS TRUE INSTEAD OF SPACE
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
            // HighFiveGuy IN FRONT
            if (linePosition == 0)
            {
                isHighFiveGuy = true;
                // if PLAYER
                // BOOL ACTION DONE
                // BUTTON PRESS || IGNORE
                
                // DO THIS AFTER ACTION
                // FIX LIST
                LineList.Clear();
                LineList.Add(LineOne);
                LineList.Add(LineTwo);
                LineList.Add(LineThree);

                // UPDATE QUEUE SYSTEM
                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListOne
                    DudeList[i].transform.position = LineList[i].transform.position;
                }
                // INCREMENT linePosition
                isHighFiveGuy = false;
            }

            // linePosition 1
            // ShyGuy IN FRONT
            else if (linePosition == 1)
            {
                isShyGuy = true;

                LineList.Clear();
                LineList.Add(LineThree);
                LineList.Add(LineOne);
                LineList.Add(LineTwo);

                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListTwo
                    DudeList[i].transform.position = LineList[i].transform.position;
                }
                // isShyGuy = false;
            }

            // linePosition 2
            // ToughGuy IN FRONT
            else if (linePosition == 2)
            {
                isToughGuy = true;

                LineList.Clear();
                LineList.Add(LineTwo);
                LineList.Add(LineThree);
                LineList.Add(LineOne);

                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListThree
                    DudeList[i].transform.position = LineList[i].transform.position;  
                }

                // isToughGuy = false;
            }
        }


    }

    void Update()
    {
        MoveLine();
    }
}
