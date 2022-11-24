using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPageTimerLastPage : NextPageTimer

{
    public GameObject credit;
    public AudioSource firstSong;
    public float songTime, creditTime;
    public GameObject popUpExit;

    Coroutine coroutine;
    public PageProgressBar progressBar;
    public MainSceneUiManager uiManager;
    public List<GameObject> addedUIs;
    public Button btnCredit;
    public Button btnReplay;

    private void Start()
    {
        btnCredit.onClick.AddListener(SkipToCredit);
    }

    void OnEnable()
    {
        foreach (GameObject item in addedUIs)
        {
            uiManager.uiObjects.Add(item.GetComponent<Image>());
            // item.SetActive(true);
        }
        coroutine = StartCoroutine(StartTimer(songTime - creditTime, creditTime));
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
        StartCoroutine(Credit(second));
    }
    public void SkipToCredit()
    {
        Debug.Log($"stop {this.coroutine}");
        StopCoroutine(this.coroutine);
        firstSong.time = songTime - creditTime;
        progressBar._time = songTime - creditTime;
        StartCoroutine(Credit(creditTime));

        uiManager.uiObjects.RemoveAt(uiManager.uiObjects.Count - 1);
        addedUIs[addedUIs.Count - 1].SetActive(false);
    }
    IEnumerator Credit(float time)
    {
        uiManager.uiObjects.Remove(addedUIs[1].GetComponent<Image>());
        addedUIs[1].SetActive(false);
        uiManager.uiObjects.Remove(btnReplay.GetComponent<Image>());    // replay button
        btnReplay.gameObject.SetActive(false);

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