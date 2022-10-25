using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_4p : MonoBehaviour
{
    public static Timer_4p instance;
    public float sceneTime;
    public Timer sceneTime_4p;
    //public GameObject real4p;
    private void Awake()
    {
        instance = this;
        sceneTime = 0;
    }
    void Update()
    {
        if (sceneTime_4p.sceneTime > 0)
            sceneTime += Time.deltaTime;
    }
}