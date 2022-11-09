using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float sceneTime;
    private void Awake()
    {
        instance = this;
        sceneTime = 0;
    }

    private void OnEnable() 
    {
        sceneTime = 0;    
    }

    void Update()
    {
        sceneTime += Time.deltaTime;
    }
}
