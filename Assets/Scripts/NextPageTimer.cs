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

    private void OnEnable()
    {
        if (!isManual)
        {
            Invoke("ShowFindNextPageUI", delay);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void StartTimer(float delay) {
        Invoke("ShowFindNextPageUI", delay);
    }

    public void ShowFindNextPageUI()
    {
        MarkerManager.Instance.currentTargetPageIndex = MarkerManager.Instance.currentPageIndex + 1;
        nextImage.SetActive(true);

        if (isPage4)
            OnboardingUIManager.Instance.ShowPage4Info(findImgDelay);
        else
            OnboardingUIManager.Instance.ShowFindImgHint(findImgDelay);

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
}