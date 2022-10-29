using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHintTimer : MonoBehaviour {
    public float delay = 60;
    public float duration = 8;

    private void OnEnable() {
        Invoke("Show", delay);
        Invoke("Hide", delay + duration);
    }

    private void OnDisable() {
        CancelInvoke();
    }

    private void Show() {
        OnboardingUIManager.Instance.Show5PBoardEnter();
    }

    private void Hide() {
        OnboardingUIManager.Instance.Show5PBoardExit();
    }
}
