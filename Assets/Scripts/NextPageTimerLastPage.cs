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

    Coroutine firstCoroutine;
    public PageProgressBar progressBar;
    public MainSceneUiManager uiManager;
    public List<GameObject> addedUIs;
    public Button btnCredit;
    private void Awake()
    {
        songTime = delay;
        foreach (GameObject item in addedUIs)
        {
            uiManager.uiObjects.Add(item.GetComponent<Image>());
        }
    }
    void OnEnable()
    {
        btnCredit.onClick.AddListener(SkipToCredit);
        firstCoroutine = StartCoroutine(StartTimer(songTime-creditTime, creditTime));
    }
    void OnDisable()
    {
        btnCredit.onClick.RemoveListener(SkipToCredit);
        credit.SetActive(false);
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
        firstSong.time = songTime - creditTime;
        progressBar._time = songTime - creditTime;
        StartCoroutine(Credit(creditTime));

        uiManager.uiObjects.RemoveAt(uiManager.uiObjects.Count - 1);
        addedUIs[addedUIs.Count - 1].SetActive(false);
    }
    IEnumerator Credit(float time)
    {
        credit.SetActive(true);
        yield return new WaitForSeconds(time);
        popUpExit.SetActive(true);
    }
}