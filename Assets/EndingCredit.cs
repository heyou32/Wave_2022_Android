using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class EndingCredit : MonoBehaviour
{
    public FadeInOut fadeEffect;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioPlayer;
    private RawImage _rawImage;

    private void Awake() 
    {
        _videoPlayer = gameObject.GetComponent<VideoPlayer>();
        _audioPlayer = gameObject.GetComponent<AudioSource>();
        _rawImage = gameObject.GetComponent<RawImage>();
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
        _videoPlayer.enabled = true;

        fadeEffect.FadeIn();

        gameObject.SetActive(false);
    }

    public void SetEnableCreditVideo(bool isEnable) 
    {
        if (isEnable) 
        {
            _videoPlayer.targetTexture.Release();
        }
        _rawImage.enabled = isEnable;
        _videoPlayer.enabled = isEnable;
    }
}
