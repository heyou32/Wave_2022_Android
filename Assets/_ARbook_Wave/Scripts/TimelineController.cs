using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    private PlayableDirector _director;

    private void Awake() 
    {
        _director = GetComponent<PlayableDirector>();
    }

    private void OnEnable() 
    {
        _director.time = 0;
    }
}
