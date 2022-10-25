using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairActive : MonoBehaviour
{
    public GameObject parentPage;
    public GameObject man;
    public float sceneEndTime;
    Timer_4p timer;

    public NextPageTimer mansTimer;
    public bool excuted;
    public GameObject womanIdle;
    public GameObject txtOpen;

    public float thisTime;
    private void Start()
    {
        //parentPage = GameObject.FindGameObjectWithTag("4P");
        timer = parentPage.GetComponent<Timer_4p>();
        ManReset();


    }
    void Update()
    {
        if (parentPage != null)
        {
            // thisTime += Time.deltaTime;
            if (!excuted && womanIdle != null && womanIdle.activeSelf)
            {
                excuted = true;
                man.SetActive(true);
                //txtOpen.GetComponent<SpriteRenderer>().enabled = false;
                //Invoke("ManReset", mansTimer.delay);
            }

        }
    }
    public void ManReset()
    {
        man.SetActive(false);
        //txtOpen.GetComponent<SpriteRenderer>().enabled = true;
    }
}