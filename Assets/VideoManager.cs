using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour {
    public static VideoManager Instance;

    public VideoClip[] clips;
    private List<VideoPlayer> videos = new List<VideoPlayer>();

    private int count;

    private void Awake() 
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        count = 0;
        VideoPlayer vp;
        foreach (var clip in clips) 
        {
            vp = gameObject.AddComponent<VideoPlayer>();
            
            vp.isLooping = false;
            vp.playOnAwake = false;
            vp.waitForFirstFrame = false;
            vp.skipOnDrop = true;
            
            vp.clip = clip;
            vp.prepareCompleted += OnPreared;

            vp.Prepare();

            videos.Add(vp);
        }
    }

    public VideoPlayer GetCachedPlayer(VideoClip clip) 
    {
        return videos.Find(vp => vp.clip.name == clip.name);
    }

    private void OnPreared(VideoPlayer vs) 
    {
        Debug.Log(vs.clip.name + " was loaded");
        vs.Pause();
        count++;
        if (count == clips.Length) {
            Debug.Log("All videos loaded");
        }
        vs.prepareCompleted -= OnPreared;
    }
}
