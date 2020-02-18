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
        LineList.Add(LineThree);
        LineList.Add(LineOne);
        LineList.Add(LineTwo);

        isHighFiveGuy = true;
        PlayerNew.newDude = true;
    }

    void MoveLine()
    {
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

            if (PlayerNew.buttonHighFive || PlayerNew.buttonFakeOut || PlayerNew.ignore)
            {
                if (PlayerNew.cooldown)
                // UPDATE QUEUE SYSTEM
                {
                    Debug.Log("do we even");
                    PlayerNew.buttonHighFive = false;
                    PlayerNew.buttonFakeOut = false;
                    PlayerNew.ignore = false;

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
                    isHighFiveGuy = false;
                    PlayerNew.cooldown = false;
                    linePosition++;
                }
            }
        }

        // linePosition 1
        // ShyGuy IN FRONT
        else if (linePosition == 1)
        {
            isShyGuy = true;

            if (PlayerNew.buttonHighFive || PlayerNew.buttonFakeOut || PlayerNew.ignore)
            {
                if (PlayerNew.cooldown)
                {
                    PlayerNew.buttonHighFive = false;
                    PlayerNew.buttonFakeOut = false;
                    PlayerNew.ignore = false;

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
                    isShyGuy = false;
                    PlayerNew.cooldown = false;
                    linePosition++;
                }
            }
        }

        // linePosition 2
        // ToughGuy IN FRONT
        else if (linePosition == 2)
        {
            isToughGuy = true;

            if (PlayerNew.buttonHighFive || PlayerNew.buttonFakeOut || PlayerNew.ignore)
            {
                if (PlayerNew.cooldown)
                {
                    PlayerNew.buttonHighFive = false;
                    PlayerNew.buttonFakeOut = false;
                    PlayerNew.ignore = false;

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
                    isToughGuy = false;
                    PlayerNew.cooldown = false;
                    linePosition++;
                }
            }
        }
    }

    void Update()
    {
        MoveLine();
    }
}
