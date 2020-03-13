using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScale : MonoBehaviour
{
    ParticleSystem m_System;

    public ParticleSystem orbParticle;
    public ParticleSystem snowParticle;
    public float size = 10f;


    void Start()
    {
        //m_System = orbParticle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //if (HitIndicator.hasPowerUp)
        //{
        //    ParticleSystem.MainModule main = m_System.main;
        //    main.startSizeMultiplier = 10;
        //}
        //else
        //{
        //    ParticleSystem.MainModule main = m_System.main;
        //    main.startSizeMultiplier = 40;
        //}
    }
}
