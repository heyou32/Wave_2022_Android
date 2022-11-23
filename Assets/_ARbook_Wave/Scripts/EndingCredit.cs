using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class EndingCredit : MonoBehaviour
{
    public FadeInOut fadeEffect;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioPlayer;

    private void Awake() 
    {
        _videoPlayer = gameObject.GetComponent<VideoPlayer>();
        _audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable() 
    {
        StartCoroutine(OnAudioEnd());    
    }

    private IEnumerator OnAudioEnd() 
    {
        yield return new WaitUntil(() => _audioPlayer.isPlaying == true);

        yield return new WaitUntil(() => _audioPlayer.isPlaying == false);

        fadeEffect.FadeOut();

        yield return StartLoadCreaditVideo();

        fadeEffect.FadeIn();

        gameObject.SetActive(false);
    }

    public void SetEnableCreditVideo(bool isEnable) 
    {
        if (isEnable)
            _videoPlayer.Play();
        else
            _videoPlayer.Stop();
    }

    public IEnumerator StartLoadCreaditVideo() 
    {

        bool isPrepared = false;
        VideoPlayer.EventHandler OnPrepared = (VideoPlayer vp) => 
        {
            isPrepared = true;
        };
        _videoPlayer.prepareCompleted += OnPrepared;
        _videoPlayer.Prepare();

        yield return new WaitUntil(() => isPrepared);

        _videoPlayer.prepareCompleted -= OnPrepared;
        _videoPlayer.frame = 1;
        _videoPlayer.Pause();
        _videoPlayer.Play();
    }
}
