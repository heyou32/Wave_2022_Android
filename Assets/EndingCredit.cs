using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class EndingCredit : MonoBehaviour
{
    public FadeInOut fadeEffect;

    private CachedVideoPlayer _videoPlayer;
    private AudioSource _audioPlayer;

    private void Awake() 
    {
        _videoPlayer = gameObject.GetComponent<CachedVideoPlayer>();
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

        yield return new WaitForSeconds(2);
        _videoPlayer.Play();

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
}
