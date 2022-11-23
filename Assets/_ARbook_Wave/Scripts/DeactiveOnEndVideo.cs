using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class DeactiveOnEndVideo : MonoBehaviour
{
    private void Start() 
    {
        CachedVideoPlayer cachedVp = GetComponent<CachedVideoPlayer>();
        VideoPlayer vp = GetComponent<VideoPlayer>();
        if (cachedVp && cachedVp.cache)
            cachedVp.cache.loopPointReached += EndReached;
        else if (vp)
            vp.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }
}
