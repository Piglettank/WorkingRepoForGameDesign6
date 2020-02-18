using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMeBanana : MonoBehaviour
{
    private SoundManager.Sound[] bananaCountArray = new SoundManager.Sound[13];

    public int soundCount = 0;

    public void PlaySound()
    {
        while (soundCount >= 0)
        {
            SoundManager.PlaySound(bananaCountArray[soundCount]);

            if (soundCount == 12 ) soundCount = 0; // RESET THE COUNTER 
            break;
        }
        Debug.Log(soundCount);
        soundCount++;
    }

    public void Start()
    {
        bananaCountArray[0] = SoundManager.Sound.bananaBounce0;
        bananaCountArray[1] = SoundManager.Sound.bananaBounce1;
        bananaCountArray[2] = SoundManager.Sound.bananaBounce2;
        bananaCountArray[3] = SoundManager.Sound.bananaBounce3;
        bananaCountArray[4] = SoundManager.Sound.bananaBounce4;
        bananaCountArray[5] = SoundManager.Sound.bananaBounce5;
        bananaCountArray[6] = SoundManager.Sound.bananaBounce6;
        bananaCountArray[7] = SoundManager.Sound.bananaBounce7;
        bananaCountArray[8] = SoundManager.Sound.bananaBounce8;
        bananaCountArray[9] = SoundManager.Sound.bananaBounce9;
        bananaCountArray[10] = SoundManager.Sound.bananaBounce10;
        bananaCountArray[11] = SoundManager.Sound.bananaBounce11;
        bananaCountArray[12] = SoundManager.Sound.bananaBounce12;
    }

    public void PlayOneSound()
    {
        SoundManager.PlaySound(SoundManager.Sound.bananaBounce0);

    }

}
