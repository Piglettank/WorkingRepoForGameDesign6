using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerGucci.PlaySound(SoundManagerGucci.SoundGucci.gucciSong);
    }

}
