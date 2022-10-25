using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ARImageTM : MonoBehaviour
{
    public ARTrackedImageManager imgTM;
    public List<GameObject> prefabsList = new List<GameObject>();
    Dictionary<string, GameObject> ImgDic = new Dictionary<string, GameObject>();
    void Awake()
    {
        foreach (GameObject img in prefabsList)
        {
            string name = img.name;
            ImgDic.Add(name, img);
        }
    }
    private void OnEnable()
    {
        imgTM.trackedImagesChanged += ImageChanged;
    }
    private void OnDisable()
    {
        imgTM.trackedImagesChanged -= ImageChanged;
    }
    void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImg(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImg(trackedImage);
        }
    }
    void UpdateImg(ARTrackedImage trackedImage)
    {
        string tName = trackedImage.referenceImage.name;
        GameObject trackedImg = ImgDic[tName];
        trackedImg.transform.position = trackedImage.transform.position;
        trackedImg.transform.rotation = trackedImage.transform.rotation;
        trackedImg.SetActive(true);
    }
}
