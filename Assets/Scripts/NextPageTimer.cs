using UnityEngine;
using UnityEngine.Video;

public class NextPageTimer : MonoBehaviour
{
    public float delay = 10;
    public bool isManual = false;
    public float findImgDelay = 3;
    public bool isPage4 = false;

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
            StartTimer(delay);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void StartTimer(float delay) {
        Invoke("ShowFindNextPageUI", delay);

        if (isPage4)
            OnboardingUIManager.Instance.ShowPage4Info(delay + findImgDelay);
        else
            OnboardingUIManager.Instance.ShowFindImgHint(delay + findImgDelay);
    }

    public void ShowFindNextPageUI()
    {
        MarkerManager.Instance.currentTargetPageIndex = MarkerManager.Instance.currentPageIndex + 1;
        nextImage.SetActive(true);
        _vp.time = 0;
        _vp.Play();

        Invoke("AROff", 1f);
    }

    void AROff()
    {
        MarkerManager.Instance.targetPageInfos[MarkerManager.Instance.currentPageIndex - 1].StartCoolDownTimer(10);
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