using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetsGucci : MonoBehaviour
{

    private static GameAssetsGucci _i;

    public static GameAssetsGucci i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssetsGucci>("GameAssetsGucci"));
            return _i;
        }
    }

    //LIST OF ASSETS
    public SoundAudioClip[] soundAudioClipArray;


    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManagerGucci.SoundGucci sound;
        public AudioClip audioClip;

    }


}

