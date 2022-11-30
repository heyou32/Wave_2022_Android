using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidieoPlayerManager : MonoBehaviour
{
    public enum Type
    {
        Type1,
        Type2
    }
    public Type type;
    VideoPlayer video;
    float curTime;
    const float firstBlackEnd = 11f;
    public bool firstCheck, secondCheck;
    //[HideIf("Type", Type.Type2)]
    public bool thirdCheck;
    public bool stopCheck;

    #region Type 1 Speed 0.4
    public float firstTypeTime = 25;
    #endregion
    #region Type 2  Speed : 0.6
    public float secondTypeTime = 18;
    //public bool firstCheck_2, secondCheck_2, thirdCheck_2, stopCheck_2;
    #endregion
    void Start()
    {
        video = GetComponent<VideoPlayer>();
    }
    private void OnEnable()
    {
        // firstSkipCheck = false;
        //secondSkipCheck = false;

        curTime = 0;
        firstCheck = false;
        secondCheck = false;
        thirdCheck = false;
        stopCheck = false;

/*        if (type == Type.Type1)
            video.playbackSpeed = 0.4f;
        else
            video.playbackSpeed = 0.6f;
*/
    }
    void Update()
    {
        curTime += Time.deltaTime;
        switch (type)
        {
            case Type.Type1:
                Type1Play();
                break;
            case Type.Type2:
                Type2Play();
                break;
        }
    }

    public void Type1Play()
    {
        if (curTime >= firstTypeTime)
        {
            if (!firstCheck)
            {
                video.time = firstBlackEnd;
                firstCheck = true;
            }
        }
        if (curTime >= firstTypeTime * 2)
        {
            if (!secondCheck)
            {
                video.time = 0;
                secondCheck = true;
            }
        }
        if (curTime >= firstTypeTime * 3)
        {
            if (!stopCheck)
            {
                video.Pause();
                stopCheck = true;
            }
        }
    }
    public void Type2Play()
    {
        #region Type 2
        if (curTime >= secondTypeTime)
        {
            if (!firstCheck)
            {
                video.time = firstBlackEnd;
                firstCheck = true;
            }
        }
        if (curTime >= secondTypeTime * 2)
        {
            if (!secondCheck)
            {
                video.time = 0;
                secondCheck = true;
            }
        }
        if (curTime >= secondTypeTime * 3)
        {
            if (!thirdCheck)
            {
                video.time = firstBlackEnd;
                thirdCheck = true;
            }
        }
        if (curTime >= secondTypeTime * 4)
        {
            if (!stopCheck)
            {
                video.Pause();
                stopCheck = true;
            }
        }
        #endregion
    }
    void VideoJump(float timer, float videoTime, bool check)
    {
        if (curTime >= timer)
        {
            if (!check)
            {
                video.time = videoTime;
                check = true;
            }
        }
    }
    void ResetVideo()
    {
        video.time = 20;
        video.Pause();
    }
}
