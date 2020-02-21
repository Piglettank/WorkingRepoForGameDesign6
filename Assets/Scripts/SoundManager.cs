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
        yeah0,
        hit0,
        tadaa0,
        hihat0
    }

    private static GameObject soundGameObject;
    private static AudioSource audioSource;

    // PLAY THE SOUND
    public static void PlaySound(Sound sound) 
    {
        // CREATE A SOUND_GAME_OBJECT IF THERE'S NOT ONE IN THE SCENE ALREADY
        if (soundGameObject == null)
        {
            soundGameObject = new GameObject("Sound Game Object");
            audioSource = soundGameObject.AddComponent<AudioSource>();
        }

        // PLAY THE EXACT SOUND
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        // REFERENCE - LOOK FOR THE CORRECT AUDIO CLIP THAT MATCHES THE SOUND WE NEED
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!"); // IN CASE THERE IS NO REFERENCED SOUND
        return null;
    }
}
