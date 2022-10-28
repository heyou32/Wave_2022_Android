using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInteraction : MonoBehaviour
{

    public BoardCardPlacement cardPlacement;

    MeshRenderer mesh;
    Animator boardAnim;

    bool sceneEnd;

    public float sceneEndTime = 67;
    private void Start()
    {
        cardPlacement.enabled = false;

        boardAnim = GetComponent<Animator>();
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
    private void Update()
    {
        if (Timer.instance.sceneTime > sceneEndTime)
        {
            sceneEnd = true;
            mesh.enabled = true;
            //boardAnim.SetTrigger("Here");

            cardPlacement.enabled = true;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other == woman && sceneEnd)
    //    {
    //        womanAnim.SetTrigger("Board");
    //    }
    //}
}
