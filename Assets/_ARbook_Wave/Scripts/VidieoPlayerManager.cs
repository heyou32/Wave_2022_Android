using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidieoPlayerManager : MonoBehaviour
{
    VideoPlayer video;
    float curTime;
    public float firstSkipTime, secondSkipTime, videoStopTime;
   public bool firstSkipCheck, secondSkipCheck,stopCheck;
    void Start()
    {
        video = GetComponent<VideoPlayer>();
    }
    void Update()
    {
        curTime += Time.deltaTime;

        if (curTime >= firstSkipTime)
        {
            if (!firstSkipCheck)
            {
                video.time = .5f;
                firstSkipCheck = true;
            }
        }

        if (curTime >= secondSkipTime)
        {
            if (!secondSkipCheck)
            {
                video.time = 0;
                secondSkipCheck = true;
            }
        }
        //ResetVideo(firstSkipTime, firstSkipCheck);
        //ResetVideo(secondSkipTime, secondSkipCheck);

        if (curTime >= videoStopTime)
        {
            video.time = 20;
            video.Pause();
            stopCheck = true;
        }
    }
    void ResetVideo(float time, bool check)
    {
        if (curTime >= time)
        {
            if (!check)
            {
                video.time = 0;
                check = true;
            }
        }
    }
        
}
