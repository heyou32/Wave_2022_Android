using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCardPlacement : CardPlacement
{
    public GameObject woman;
    Animator anim;

    public GameObject nextImage;
    Animator animator;


    public GameObject[] arPrefab;
    public float delay;

    public GameObject board;
    private void Start()
    {
        nextImage.SetActive(true);
        animator = nextImage.GetComponent<Animator>();
        anim = woman.GetComponent<Animator>();
    }
    protected override void OnCardPlacement()
    {
        base.OnCardPlacement();
        Debug.Log("Touched");
        anim.SetTrigger("Board");
        board.SetActive(false);
        Invoke("NextPage", delay);
    }
    void NextPage()
    {
        nextImage.SetActive(true);
        animator.SetTrigger("SceneEnd");

        for (int i = 0; i < arPrefab.Length; i++)
        {
            arPrefab[i].SetActive(false);

        }
        Invoke("VideoOff", 4);
    }
    void VideoOff()
    {
        nextImage.SetActive(false);

    }
}