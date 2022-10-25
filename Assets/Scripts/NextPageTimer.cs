using UnityEngine;
using UnityEngine.Video;

public class NextPageTimer : MonoBehaviour
{
    public float delay = 10;
    public bool isManual = false;
    public float findImgDelay = 3;

    public GameObject nextImage;

    public GameObject[] arPrefab;

    private VideoPlayer _vp;


    private void Awake()
    {
        _vp = nextImage.GetComponent<VideoPlayer>();
        if(_vp)
        _vp.loopPointReached += VideoOff;
    }
    private void OnEnable()
    {
        if (!isManual)
        {
            Invoke("ShowFindNextPageUI", delay);
            Invoke("ShowFindImgHint", delay + findImgDelay);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void ShowFindNextPageUI()
    {
        MarkerManager.Instance.currentTargetPageIndex += 1;
        nextImage.SetActive(true);
        _vp.time = 0;
        _vp.Play();
    }

    public void ShowFindImgHint() 
    {
        OnboardingUIManager.Instance.ShowFindImgHint();
    }

    void AROff()
    {
        for (int i = 0; i < arPrefab.Length; i++)
        {
            arPrefab[i].SetActive(false);
        }

    }
    void VideoOff(VideoPlayer vp)
    {
        nextImage.SetActive(false);
    }
}