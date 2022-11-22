using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class MainSceneUiManager : MonoBehaviour
{
    public float uiShowingDuration = 3;
    public float animDuration = 0.7f;
    public OnboardingUIManager onboardingUI;
    public FadeInOut fadeInOut;
    public ARPlaneManager planeManager;
    public List<Image> uiObjects;
//    public Image[] uiObjects;
    private Coroutine hideTimer;
    private bool isShowing = false;

    private void Start() {
        SetImagesAlpha(uiObjects, 0);
        Invoke("ShowFindPlane", 1.5f);
    }

    private void ShowFindPlane() {
        planeManager.enabled = true;
        onboardingUI.ShowUiByName("FindPlane");
    }

    public void OnClickScreen() {
        MarkerManager.Instance.RequestFixCurrentPage();

        if (!isShowing) {
            isShowing = true;
            SetActiveAllBtn(true);
            StartCoroutine(IeUiFadeAnim(0, 1));
        }

        if (hideTimer != null) {
            StopCoroutine(hideTimer);
            SetImagesAlpha(uiObjects, 1);
        }
        hideTimer = StartCoroutine(IeStartHideTimer(uiShowingDuration));
    }

    public void GoToStartScene() {
        fadeInOut.FadeOut();
        Invoke("LoadStartScene", 2);
    }

    private void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void GoToArScene() {
        SceneManager.LoadScene(1);
    }

    public void QuitApplication() {
        Application.Quit();
    }

    private IEnumerator IeStartHideTimer(float delay) {
        yield return new WaitForSeconds(delay);
        yield return IeUiFadeAnim(1, 0);
        SetActiveAllBtn(false);
        isShowing = false;
    }

    private void SetActiveAllBtn(bool isActive) 
    {
        foreach (var ui in uiObjects) {
            ui.gameObject.SetActive(isActive);
        }
    }

    private IEnumerator IeUiFadeAnim(float from, float to) {
        float time = 0;
        float alphaValue;

        while (time < animDuration) {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();

            alphaValue = Mathf.Lerp(from, to, time / animDuration);

            SetImagesAlpha(uiObjects, alphaValue);
        }

        SetImagesAlpha(uiObjects, to);
    }

    private void SetImagesAlpha(List<Image> images, float alpha) {
        foreach(var image in images) {
            SetImageAlpha(image, alpha);
        }
    }

    private void SetImageAlpha(Image image, float alpha) {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}
