using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public static int bananaCount = 0;
    public static bool isBananaEaten = false;

    public int soundCount = 0;
    private SoundManager.Sound[] bananaCountArray = new SoundManager.Sound[13];

    bool bananaSound;
    float bananaTimer; 

    void Start()
    {
        bananaTimer = 0f;
        bananaCount = 1;

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

        bananaSound = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            while (soundCount >= 0)
            {
                bananaSound = true;
                if (bananaTimer > 0.2f)
                {
                    SoundManager.PlaySound(bananaCountArray[soundCount]);
                    bananaSound = false;
                    bananaTimer = 0f;
                }
                

                if (soundCount == 12) soundCount = 0; // RESET THE COUNTER 
                break;
            }
            soundCount++;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // WHEN BANANA COLLIDES WITH MOUTH
        if (collider.gameObject.tag == "Mouth")
        {
            // STATIC BOOL FOR EATING BANANA ANIMATION
            isBananaEaten = true;

            SoundManager.PlaySound(SoundManager.Sound.eating0);
            SoundManager.PlaySound(SoundManager.Sound.yeah0);

            Destroy(gameObject);
            bananaCount--;
        }
    }

    void Update()
    {
        if (bananaSound == true)
        {
            bananaTimer += Time.deltaTime;
        }
    }
}
