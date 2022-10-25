using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [AddComponentMenu("Rendering/SetRenderQueue")]
public class MaskRender : MonoBehaviour
{
    [SerializeField]
    int[] m_Queues = new int[] { 3000 };
    private void Awake()
    {
        Material[] mats = GetComponent<Renderer>().materials;
        for (int i = 0; i < mats.Length &&i<m_Queues.Length; i++)
        {
            mats[i].renderQueue = m_Queues[i];
        }
    }
}
