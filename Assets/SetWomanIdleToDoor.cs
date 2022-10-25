using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWomanIdleToDoor : MonoBehaviour
{

    public StairActive stair;
    public GameObject womanIdle;
    public GameObject txtOepn;
    // Start is called before the first frame update
    void Start()
    {
        stair.ManReset();
        stair.womanIdle = womanIdle;
        stair.excuted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
