using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dudes : MonoBehaviour
{
    public GameObject DudeOne, DudeTwo, DudeThree;
    public GameObject LineOne, LineTwo, LineThree;

    public List<GameObject> DudeList;
    public List<GameObject> LineListOne;
    public List<GameObject> LineListTwo;
    public List<GameObject> LineListThree;

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
    }

    void MoveLine()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            linePosition++;
            
            if (linePosition == 1)
            {
                for (int i = 0; i < DudeList.Count; i++)
                {
                    DudeList[i].transform.position = LineListOne[i].transform.position;
                }
            }

            else if (linePosition == 2)
            {
                for (int i = 0; i < DudeList.Count; i++)
                {
                    DudeList[i].transform.position = LineListTwo[i].transform.position;
                }
            }

            else if (linePosition == 3)
            {
                for (int i = 0; i < DudeList.Count; i++)
                {
                    DudeList[i].transform.position = LineListThree[i].transform.position;  
                }
            }

            if (linePosition >= 3)
            {
                linePosition = 0;
            }

            Debug.Log(linePosition);
        }
    }

    
    void Update()
    {
        MoveLine();
    }
}
