using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 1st song : 180
// 2nd song : 200
// credit        : 92
public class NextPageTimerLastPage : NextPageTimer
{
    public GameObject credit;
    public AudioSource firstSong;
    public AudioSource secondSong;
    public float firstSongTime, secondSongTime, creditTime;
    public GameObject popUpExit;

    Coroutine coroutine;
    public PageProgressBar progressBar;
    public MainSceneUiManager uiManager;
    public List<GameObject> addedUIs;
    public Button btnCredit;
    public Button btnSecond;

    private void Start()
    {
        secondSong = GetComponent<AudioSource>();
        btnCredit.onClick.AddListener(SkipToCredit);
        btnSecond.onClick.AddListener(SkipToSencond);
    }
    void OnEnable()
    {
        foreach (GameObject item in addedUIs)
        {
            uiManager.uiObjects.Add(item.GetComponent<Image>());
           // item.SetActive(true);
        }
        coroutine = StartCoroutine(StartTimer(firstSongTime, secondSongTime));
    }
    void OnDisable()
    {
        foreach (GameObject item in addedUIs)
        {
            uiManager.uiObjects.Remove(item.GetComponent<Image>());
            item.SetActive(false);
        }
    }


    IEnumerator StartTimer(float first, float second)
    {
        Debug.Log($"{this.coroutine} is started");
        yield return new WaitForSeconds(first);

        StartCoroutine(SecondSongPlay());
        //StartCoroutine(Credit(second));
    }

    public void SkipToSencond()
    {
        StopCoroutine(this.coroutine);
        firstSong.Stop();
        progressBar._time = firstSongTime;
        coroutine = StartCoroutine(SecondSongPlay());
    }
    public void SkipToCredit()
    {
        Debug.Log($"stop {this.coroutine}");
        StopCoroutine(this.coroutine);
        firstSong.Stop();
        secondSong.time = secondSongTime - creditTime;
        secondSong.Play();
        progressBar._time = firstSongTime + secondSongTime - creditTime;
        StartCoroutine(Credit(creditTime));
    }
    IEnumerator SecondSongPlay()
    {
        btnSecond.gameObject.SetActive(false);
        uiManager.uiObjects.Remove(addedUIs[2].GetComponent<Image>());
        addedUIs[2].SetActive(false);

        secondSong.Play();
        yield return new WaitForSeconds(secondSongTime - creditTime);
        StartCoroutine(Credit(creditTime));
    }
    IEnumerator Credit(float time)
    {
        btnSecond.gameObject.SetActive(false);
        uiManager.uiObjects.Remove(addedUIs[1].GetComponent<Image>());
        addedUIs[1].SetActive(false);
        uiManager.uiObjects.Remove(addedUIs[2].GetComponent<Image>());
        addedUIs[2].SetActive(false);

        EndingCredit ed = credit.GetComponent<EndingCredit>();

        ed.fadeEffect.FadeOut();
        yield return new WaitForSeconds(2);
        ed.fadeEffect.FadeIn();

        credit.SetActive(true);

        ed.SetEnableCreditVideo(true);
        yield return new WaitForSeconds(time);
        // popUpExit.SetActive(true);
        ed.SetEnableCreditVideo(false);
        MarkerManager.Instance.targetPageInfos[MarkerManager.Instance.currentPageIndex - 1].StartCoolDownTimer(10);
        gameObject.SetActive(false);
    }
}
