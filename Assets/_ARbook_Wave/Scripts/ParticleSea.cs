using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSea : MonoBehaviour
{
    public ParticleSystem particle;
    ParticleSystem.Particle[] particlesArray;
    public int seaResolution = 25;

    public float spacing = 0.25f;

    public float noiseScale = 0.2f;
    public float heightScale = 3f;

    private float perlinNoiseAnimX = 0.01f;
    private float perlinNoiseAnimY = 0.01f;

    public Gradient colorGradient;

    void Start()
    {
        particlesArray = new ParticleSystem.Particle[seaResolution * seaResolution];
        var main = particle.main;
        main.maxParticles = seaResolution * seaResolution;
        particle.Emit(seaResolution * seaResolution);
        particle.GetParticles(particlesArray);
              
       // GetParticles();

        //this.transform.localScale = new Vector3(.25f,.25f,.25f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < seaResolution; i++)
        {
            for (int j = 0; j < seaResolution; j++)
            {
                float zPos = Mathf.PerlinNoise(i * noiseScale + perlinNoiseAnimX, j * noiseScale + perlinNoiseAnimY);
                particlesArray[i * seaResolution + j].startColor = colorGradient.Evaluate(zPos);
                particlesArray[i * seaResolution + j].position = new Vector3(i * spacing, zPos * heightScale, j * spacing);
            }
        }
        perlinNoiseAnimX += 0.01f; perlinNoiseAnimY += 0.01f;
        particle.SetParticles(particlesArray, particlesArray.Length);


    }
    void GetParticles()
    {        
        for (int i = 0; i < seaResolution; i++)
        {
            for (int j = 0; j < seaResolution; j++)
            {
                float zPos = Mathf.PerlinNoise(i * noiseScale, j * noiseScale) * heightScale;
                particlesArray[i * seaResolution + j].position = new Vector3(i * spacing, zPos, j * spacing);
            }
        }
        particle.SetParticles(particlesArray, particlesArray.Length);
    }
}
