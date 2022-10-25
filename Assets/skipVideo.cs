using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class skipVideo : MonoBehaviour
{
    bool skip;
    RawImage rawimage;
    public Texture skipImage;
    public CanvasGroup uiGroup;
    public Animator canvas;

    void Start()
    {
        rawimage = GetComponent<RawImage>();
        uiGroup.gameObject.SetActive(false);
    }

    void Update()
    {
        if (skip) return;

        if ((Input.GetMouseButton(0) || Input.touchCount > 0))
        {
            canvas.enabled = false;
            rawimage.texture = skipImage;

            uiGroup.gameObject.SetActive(true);
            uiGroup.alpha = 1;

            skip = true;
        }
    }
}
