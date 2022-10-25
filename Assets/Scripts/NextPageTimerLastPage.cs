using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageTimerLastPage : MonoBehaviour
{
    public float delay = 150;
    public GameObject credit;
    public GameObject vedioManager;
    public bool isManual = false;
    public float endend;
    public GameObject endingUI;
    private void Awake()
    {
        endingUI.SetActive(false);
    }
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

    public void ShowFindNextPageUI()
    {
        vedioManager.SetActive(true);
        credit.SetActive(true);
        Invoke("PopUp", endend);
    }
    void PopUp()
    {
        endingUI.SetActive(true);

    }
}
