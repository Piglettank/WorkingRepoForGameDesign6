using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitIndicator : MonoBehaviour
{
    public static int spreadPower = 0;
    public static int rotationPower = 0;

    public static bool hasPowerUp = false;

    CapsuleCollider skierCollider;

    void GetHigh(ref Collider other)
    {
        SkierMovement skier = other.GetComponent<SkierMovement>();
        skier.onBeatWait = true;

        SoundManagerGucci.PlaySound(SoundManagerGucci.SoundGucci.cocaine);
        skier.playedCocaine = true;

        skierCollider = other.gameObject.GetComponent<CapsuleCollider>();
        skierCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        //POWER UP 1 - GREATER RANGE
        if (other.gameObject.CompareTag("skiergreen"))
        {
            GetHigh(ref other);

            hasPowerUp = true;
            spreadPower++;
            rotationPower++;
        }

        //POWER UP 2 - FASTER ROTATION
        if (other.gameObject.CompareTag("skierblue"))
        {
            GetHigh(ref other);

            hasPowerUp = true;
            //POWER UP
        }

        //POWER UP 3 - BIGGER SKIERS
        if (other.gameObject.CompareTag("skierred"))
        {
            GetHigh(ref other);

            hasPowerUp = true; 
        }
    }
}
