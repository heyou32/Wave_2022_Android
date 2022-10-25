using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternOffsetSmall : MonoBehaviour
{


    float y = 0.5f;
    float yOffset;

    void Update()
    {

        if (yOffset == 0)
        {

            yOffset -= (Time.deltaTime * y) / 20f;
            gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, yOffset);
            gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, yOffset);
            gameObject.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));

        }



        if (yOffset==30f)
        {
            
            yOffset += (Time.deltaTime * y) / 20f;
            gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, yOffset);
            gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, yOffset);
            gameObject.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));

        }


    }
}
