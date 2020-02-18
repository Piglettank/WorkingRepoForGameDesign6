using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        bananaBounce0,
        bananaBounce1,
        bananaBounce2,
        bananaBounce3,
        bananaBounce4,
        bananaBounce5,
        bananaBounce6,
        bananaBounce7,
        bananaBounce8,
        bananaBounce9,
        bananaBounce10,
        bananaBounce11,
        bananaBounce12,
        slap,
    }
    
    public static int bounceCount = 0;
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        // LOOK FOR THE CORRECT AUDIO CLIP THAT MATCHES THE SOUND WE NEED
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null; 
    }
}
