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
    }

    void MoveLine()
    {
        // WHEN PRESS SPACE (TEMPORARY)
        // WHEN COOLDOWN BOOL IS TRUE INSTEAD OF SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // linePosition INCREMENTS BY 1 (TEMPORARY)
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
                // UPDATE QUEUE SYSTEM
                LineList.Clear();
                LineList.Add(LineOne);
                LineList.Add(LineTwo);
                LineList.Add(LineThree);

                // MOVE DUDES
                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineList
                    DudeList[i].transform.position = LineList[i].transform.position;
                }
                //linePosition++;
                isHighFiveGuy = false;
            }

            // linePosition 1
            // ShyGuy IN FRONT
            else if (linePosition == 1)
            {
                isShyGuy = true;
                // if PLAYER
                // BOOL ACTION DONE
                // BUTTON PRESS || IGNORE

                // DO THIS AFTER ACTION
                // UPDATE QUEUE SYSTEM
                LineList.Clear();
                LineList.Add(LineThree);
                LineList.Add(LineOne);
                LineList.Add(LineTwo);

                // MOVE DUDES
                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineList
                    DudeList[i].transform.position = LineList[i].transform.position;
                }
                //linePosition++;
                isShyGuy = false;
            }

            // linePosition 2
            // ToughGuy IN FRONT
            else if (linePosition == 2)
            {
                isToughGuy = true;
                // if PLAYER
                // BOOL ACTION DONE
                // BUTTON PRESS || IGNORE

                // DO THIS AFTER ACTION
                // UPDATE QUEUE SYSTEM
                LineList.Clear();
                LineList.Add(LineTwo);
                LineList.Add(LineThree);
                LineList.Add(LineOne);

                // MOVE DUDES
                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineList
                    DudeList[i].transform.position = LineList[i].transform.position;  
                }
                //linePosition++;
                isToughGuy = false;
            }
        }
    }

    void Update()
    {
        MoveLine();
    }
}
