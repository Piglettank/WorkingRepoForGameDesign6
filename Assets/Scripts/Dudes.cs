using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dudes : MonoBehaviour
{
    private Animator animator;

    public GameObject DudeOne, DudeTwo, DudeThree;
    public GameObject LineOne, LineTwo, LineThree;

    public List<GameObject> DudeList;
    public List<GameObject> LineListOne;
    public List<GameObject> LineListTwo;
    public List<GameObject> LineListThree;

    private int trust = 0;

    public int linePosition = 0;

    void Start()
    {
        DudeList = new List<GameObject>();
        DudeList.Add(DudeOne);
        DudeList.Add(DudeTwo);
        DudeList.Add(DudeThree);

        LineListOne = new List<GameObject>();
        LineListOne.Add(LineThree);
        LineListOne.Add(LineTwo);
        LineListOne.Add(LineOne);

        LineListTwo = new List<GameObject>();
        LineListTwo.Add(LineTwo);
        LineListTwo.Add(LineOne);
        LineListTwo.Add(LineThree);

        LineListThree = new List<GameObject>();
        LineListThree.Add(LineOne);
        LineListThree.Add(LineThree);
        LineListThree.Add(LineTwo);

        DudeOne.GetComponent<Animator>();
    }

    void MoveLine()
    {
        // WHEN PRESS SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // linePosition INCREMENTS BY 1
            linePosition++;

            // LINEPOSITION CANNOT BE MORE THAN 3
            if (linePosition == 4)
            {
                linePosition = 1;
            }

            // linePosition 1
            if (linePosition <= 1)
            {
                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListOne
                    DudeList[i].transform.position = LineListOne[i].transform.position;
                }
            }

            // linePosition 2
            else if (linePosition == 2)
            {
                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListTwo
                    DudeList[i].transform.position = LineListTwo[i].transform.position;
                }
            }

            // linePosition 3
            else if (linePosition == 3)
            {
                for (int i = 0; i < DudeList.Count; i++)
                {
                    // COMPARE DudeList WITH LineListThree
                    DudeList[i].transform.position = LineListThree[i].transform.position;  
                }
            }
        }
    }

    void Update()
    {
        MoveLine();
    }
}
