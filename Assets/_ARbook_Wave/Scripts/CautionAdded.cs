using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionAdded : MonoBehaviour
{
    public GameObject cautionTab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickTab()
    {
        cautionTab.SetActive(true);
    }
}
