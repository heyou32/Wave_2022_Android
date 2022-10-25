using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class DeactiveOnEndVideo : MonoBehaviour
{
    private VideoPlayer vp;

    void Awake()
    {
        vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }
}
