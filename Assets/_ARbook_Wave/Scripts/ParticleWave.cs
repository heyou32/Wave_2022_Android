using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWave : MonoBehaviour
{
    public ParticleSystem particle;
    ParticleSystem.Particle[] particlesArray;
    public int waveDPI = 25;

    public float spacing = .25f;
    void Start()
    {
        particlesArray = new ParticleSystem.Particle[waveDPI * waveDPI];
        var main = particle.main;
        main.maxParticles = waveDPI * waveDPI;
        particle.Emit(waveDPI * waveDPI);
        particle.GetParticles(particlesArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetParticles()
    {
        for (int i = 0; i < waveDPI; i++)
        {
            for (int j = 0; j < waveDPI; j++)
            {
                particlesArray[i * waveDPI + j].position = new Vector3(i * spacing, j * spacing, 0);
            }
        }
        particle.SetParticles(particlesArray, particlesArray.Length);
    }
}
