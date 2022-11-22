using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class DeactiveOnEndVideo : MonoBehaviour
{
    private CachedVideoPlayer vp;

    private void Start() 
    {
        vp = GetComponent<CachedVideoPlayer>();
        vp.cache.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }
}
