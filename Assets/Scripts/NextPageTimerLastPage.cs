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

    Coroutine coroutine;
    public PageProgressBar progressBar;
    public MainSceneUiManager uiManager;
    public List<GameObject> addedUIs;
    private void Start()
    {
        //endingUI.SetActive(false);
        foreach (GameObject item in addedUIs)
        {
            uiManager.uiObjects.Add(item.GetComponent<Image>());
        }
    }
    void OnEnable()
    {
        coroutine = StartCoroutine(StartTimer(firstSongTime, secondSongTime));
    }


    IEnumerator StartTimer(float first, float second)
    {
        Debug.Log($"{coroutine} is started");
        yield return new WaitForSeconds(first);
        StartCoroutine(Credit(second));
    }
    public void SkipToCredit()
    {
        StopCoroutine(coroutine);
        firstSong.Stop();
        progressBar._time = 180;
        StartCoroutine(Credit(secondSongTime));

        uiManager.uiObjects.RemoveAt(uiManager.uiObjects.Count - 1);
        addedUIs[addedUIs.Count - 1].SetActive(false);
    }
    IEnumerator Credit(float time)
    {
        Debug.Log("why");
        credit.SetActive(true);
        yield return new WaitForSeconds(time);
        popUpExit.SetActive(true);
    }
    //public void ShowFindNextPageUI()
    //{
    //    vedioManager.SetActive(true);
    //    credit.SetActive(true);
    //    Invoke("PopUp", endend);
    //}
    //void PopUp()
    //{
    //    endingUI.SetActive(true);

    //}
}
