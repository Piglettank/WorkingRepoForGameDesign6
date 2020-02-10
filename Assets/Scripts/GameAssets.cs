using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets _i;

    public AudioClip HF_Happy_HF;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("Game Assets"));
            return _i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
