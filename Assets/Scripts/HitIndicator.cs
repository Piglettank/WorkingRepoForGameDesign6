﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitIndicator : MonoBehaviour
{
    public static int spreadPower = 0;
    public static bool hasPowerUp = false;

    CapsuleCollider skierCollider;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "skierBlue" && other.gameObject.tag == "skierGreen" && other.gameObject.tag == "skierRed")
        {
            SkierMovement skier = other.GetComponent<SkierMovement>();
            skier.onBeatWait = true;

            SoundManagerGucci.PlaySound(SoundManagerGucci.SoundGucci.cocaine);
            skier.playedCocaine = true;

            skierCollider = other.gameObject.GetComponent<CapsuleCollider>();
            skierCollider.enabled = false;

            hasPowerUp = true;
            spreadPower++;
        }
    }
}
