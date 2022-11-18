using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CachedVideoPlayer : MonoBehaviour
{
    public VideoClip clip;
    public bool PlayOnAwake = true;
    public bool isLooping = false;
    public VideoRenderMode renderMode = VideoRenderMode.CameraNearPlane;
    public RenderTexture renderTexture;
    public VideoAspectRatio aspectRatio = VideoAspectRatio.FitHorizontally;
    public VideoAudioOutputMode audioOutputMode = VideoAudioOutputMode.None;
    public VideoPlayer cache;

    private void Awake() 
    {
        cache = VideoManager.Instance.GetCachedPlayer(clip);
        cache.aspectRatio = aspectRatio;
        cache.audioOutputMode = audioOutputMode;
        cache.renderMode = renderMode;
        cache.targetTexture = renderTexture;
    }

    private void OnEnable() 
    {
        cache.isLooping = isLooping;
        if (PlayOnAwake)
            Play();
    }

    private void OnDisable() 
    {
        Stop();
    }

    public void Play() 
    {
        cache.frame = 0;
        cache.Play();
    }

    public void Stop() 
    {
        cache.Pause();
        cache.frame = 0;
    }
}
