using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitIndicator : MonoBehaviour
{
    public static int spreadPower = 0;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "skiers")
        {
            SkierMovement.onBeatWait = true;
            //spreadPower++;
            Debug.Log("SKIER HIT");
        }
    }

    void Update()
    {
        
    }
}
