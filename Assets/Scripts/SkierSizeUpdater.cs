using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkierSizeUpdater : MonoBehaviour
{
    Vector3 skierSize = new Vector3(0.05f, 0.05f, 0);
    public static Vector3 addedHeight = new Vector3(0f, 2.75f, 0f);

    float currentSize = 0;



    void Update()
    {
        //POWER UP 3 TRIGGER
        if (HitIndicator.increasedSize > currentSize)
        {
            gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0f);
            currentSize++;
        }
    }
}
