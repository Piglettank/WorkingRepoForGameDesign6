using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool hasHit = false;

    public static float actionTimer = 0f;
    public static float actionComplete = 2f;

    public static int bluePower = 0;
    public static int greenPower = 0;
    public static int yellowPower = 0;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // HIT SKIER GREEN
        if (other.gameObject.tag == "Skier")
        {
            hasHit = true;
            Debug.Log("bullet hit skier");
        }
        //// HIT SKIER BLUE
        //else if (other.gameObject.tag == "Skier")
        //{
        //    bluePower++;
        //    hasHit = true;
        //    Debug.Log("bullet hit skier");
        //}
        //// HIT SKIER YELLOW
        //else if (other.gameObject.tag == "Skier")
        //{
        //    yellowPower++;
        //    hasHit = true;
        //    Debug.Log("bullet hit skier");
        //}
    }

    void Update()
    {

    }
}
