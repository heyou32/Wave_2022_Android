using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUiManager : MonoBehaviour
{
    public enum SceneType
    {
        TitleScene,
        ARScene
    }
    public SceneType sceneType;

    //public Popup_Common popupExit;
   // public Popup_Settings popupSettings;

    CanvasGroup canvasGroup;
    float timer;
    public float fadeTime = 1.5f;

    AsyncOperation nextScene;
    public GameObject loadingGrp;
    private void Start()
    {
        if (sceneType == 0)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            //Fade(true);
            //StartCoroutine(LoadScene());
        }

    }
    public void OnClickBtnExit()
    {
  //      popupExit.gameObject.SetActive(true);
    }

    public void OnClickSetting()
    {
  //      popupSettings.gameObject.SetActive(true);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GoToArScene()
    {
        // Invoke("LoadArScene", 2);
        StartCoroutine(LoadAsyncScene());
    }

    public void QuitApplication()
    {
        Application.Quit();
    }


    IEnumerator LoadScene()
    {
        yield return null;
       var nextScene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        nextScene.allowSceneActivation = false;
        if (nextScene.isDone)
            Debug.Log(0);
        else
            Debug.Log(1);
    }
    IEnumerator LoadAsyncScene()
    {
        loadingGrp.SetActive(true);
        DontDestroyOnLoad(loadingGrp);

        yield return null;
        nextScene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        nextScene.allowSceneActivation = false;

        // float timer = 0.0f;
        while (!nextScene.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            //Debug.Log($"progress : {nextScene.progress}, timer : {timer}");

            if (nextScene.progress < 0.9f)
            {
                if (timer < fadeTime)
                {
                    Fade(false);
                    //canvasGroup.alpha = Mathf.Lerp(1, 0, fadeTime);
                }
            }
            else
            {
                if (timer < fadeTime)
                {
                    //Debug.Log(timer);
                    Fade(false);
                    //canvasGroup.alpha = Mathf.Lerp(1, 0, fadeTime);
                }
                else
                {
                    Debug.Log("loading done.");
                    nextScene.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    IEnumerator Fade(bool isFadeIn)
    {
        //  float timer = 0f;
        Debug.Log(timer);
        while (timer <= fadeTime)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 2f;
            canvasGroup.alpha = Mathf.Lerp(isFadeIn ? 0 : 1, isFadeIn ? 1 : 0, timer);
            Debug.Log(canvasGroup.alpha);
        }

        //if (!isFadeIn)
        //    gameObject.SetActive(false);

    }
}
