using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPageTimerLastPage : NextPageTimer

{
    public GameObject credit;
    public AudioSource firstSong;
    public float firstSongTime, secondSongTime;
    public GameObject popUpExit;

    Coroutine firstCoroutine;
    public PageProgressBar progressBar;
    public MainSceneUiManager uiManager;
    public List<GameObject> addedUIs;
    public Button btnCredit;

    void OnEnable()
    {
        foreach (GameObject item in addedUIs) {
            uiManager.uiObjects.Add(item.GetComponent<Image>());
        }

        btnCredit.onClick.AddListener(SkipToCredit);
        firstCoroutine = StartCoroutine(StartTimer(firstSongTime, secondSongTime));
    }
    void OnDisable()
    {
        btnCredit.onClick.RemoveListener(SkipToCredit);
        foreach (GameObject item in addedUIs) {
            uiManager.uiObjects.Remove(item.GetComponent<Image>());
        }
    }


    IEnumerator StartTimer(float first, float second)
    {
        Debug.Log($"{this.firstCoroutine} is started");
        yield return new WaitForSeconds(first);
        StartCoroutine(Credit(second));
    }
    public void SkipToCredit()
    {
        Debug.Log($"stop {this.firstCoroutine}");
        StopCoroutine(this.firstCoroutine);
        firstSong.Stop();
        progressBar._time = firstSongTime;
        StartCoroutine(Credit(secondSongTime));
    }
    IEnumerator Credit(float time)
    {
        uiManager.uiObjects.Remove(addedUIs[1].GetComponent<Image>());
        addedUIs[1].SetActive(false);
        EndingCredit ed = credit.GetComponent<EndingCredit>();

        ed.fadeEffect.FadeOut();
        yield return new WaitForSeconds(2);
        ed.fadeEffect.FadeIn();
        
        credit.SetActive(true);

        ed.SetEnableCreditVideo(true);
        yield return new WaitForSeconds(time);
        // popUpExit.SetActive(true);
        ed.SetEnableCreditVideo(false);
        gameObject.SetActive(false);
    }
}
