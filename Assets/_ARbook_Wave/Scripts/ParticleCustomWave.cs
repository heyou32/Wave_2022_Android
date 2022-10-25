using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCustomWave : MonoBehaviour
{
    //public ParticleSystem particle;
    public ParticleSystem.ShapeModule scale;
    public float startSize = 0.4f;
    public float maxSize = 1.85f;
    public float duration = 10f;
    void Start()
    {
        //particle = gameObject.GetComponent<ParticleSystem>();
        scale = gameObject.GetComponent<ParticleSystem>().shape;
        scale.scale = new Vector3(startSize, 0.13f, 0.28f);
        //Spread();
    }
    private void Update()
    {
        if (startSize < maxSize)
        {
            startSize += Time.deltaTime*.1f;
            scale.scale = new Vector3(startSize, 0.13f, 0.28f);
        }
        //Vector3 start = new Vector3(startSize, 0.13f, 0.28f);
        //Vector3 max = new Vector3(maxSize, 0.13f, 0.28f);
        //Vector3 scaleX= Vector3.Lerp(start, max, duration);
        //scale.scale = scaleX;

        print(scale.scale);
    }
    void Spread()
    {
       
            
            //for (float i = startSize; i < maxSize; i++)
        //{
        //    i++;
        //    scale.scale = new Vector3(i, .13f, .28f);
        //}
    }
}
