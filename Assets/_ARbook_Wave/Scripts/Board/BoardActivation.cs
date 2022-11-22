using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardActivation : MonoBehaviour
{
    public List<GameObject> list;
    private void OnEnable() 
    {
        list.ForEach(o => o.SetActive(true));
    }

    private void OnDisable() 
    {
        list.ForEach(o => o.SetActive(false));
    }
}
