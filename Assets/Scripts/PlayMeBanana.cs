using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMeBanana : MonoBehaviour
{
    public void PlaySound()
    {
        SoundManager.PlaySound(SoundManager.Sound.bananaBounce0); 
    }

}
