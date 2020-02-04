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
    }

    void MoveLine()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < DudeList.Count; i++)
            {
                DudeList[i].transform.position = LineList[i].transform.position;
                Debug.Log("Dude List: " + DudeList[i].transform.position);
                Debug.Log("Line List: " + LineList[i].transform.position);
            }

            //if (DudeOne.transform.position == LineOne.transform.position)
            //{
            //    DudeOne.transform.position = LineThree.transform.position;
            //}
            //else if (DudeOne.transform.position == LineTwo.transform.position)
            //{
            //    DudeOne.transform.position = LineOne.transform.position;
            //}
            //else if (DudeOne.transform.position == LineThree.transform.position)
            //{
            //    DudeOne.transform.position = LineTwo.transform.position;
            //}

            Debug.Log("Line moves");
        }
    }

    
    void Update()
    {
        MoveLine();
    }
}
