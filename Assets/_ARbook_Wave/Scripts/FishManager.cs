using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    //  public List<GameObject> positionList =new List<GameObject>();
    //  public List<GameObject> positionListSecond =new List<GameObject>();
    public List<GameObject> fishList = new List<GameObject>();
    public List<GameObject> fishListSecond = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < fishList.Count; i++)
        {
            fishList[i].SetActive(true);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
