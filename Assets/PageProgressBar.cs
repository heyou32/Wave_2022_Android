using UnityEngine;
using UnityEngine.UI;

public class PageProgressBar : MonoBehaviour
{
    public NextPageTimer nextPageTimer;
    private Image _progressBarCursor;
    private CanvasGroup _cg;
    private float _pageLength;
    private float _time;
    private bool _show = false;

    private void Awake() 
    {
        _progressBarCursor = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _pageLength = nextPageTimer.delay;
        _cg = GetComponent<CanvasGroup>();
    }

    private void OnEnable() 
    {
        _time = 0;
        _show = true;
        _cg.alpha = 1;
    }

    void Update() {
        if (_show == false) return;

        _progressBarCursor.fillAmount = _time / _pageLength;
        _time += Time.deltaTime;

        if (_progressBarCursor.fillAmount >= 1) 
        {
            _show = false;
            _cg.alpha = 0;
        }
    }
}
