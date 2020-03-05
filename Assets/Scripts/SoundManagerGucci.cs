using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManagerGucci
{
    public enum SoundGucci
    {
         gucciSong,
    }

    private static GameObject soundGameObject;
    private static AudioSource audioSource;

    // PLAY THE SOUND
    public static void PlaySound(SoundGucci sound)
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


    private static AudioClip GetAudioClip(SoundGucci sound)
    {
        // REFERENCE - LOOK FOR THE CORRECT AUDIO CLIP THAT MATCHES THE SOUND WE NEED
        foreach (GameAssetsGucci.SoundAudioClip soundAudioClip in GameAssetsGucci.i.soundAudioClipArray)
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
