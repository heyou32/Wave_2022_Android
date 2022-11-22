using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCardPlacement : CardPlacement
{
    public PageProgressBar progressBar;
    public GameObject woman;
    public NextPageTimer nextPageTimer;
    Animator anim;

    public GameObject board;

    private void Start()
    {
        anim = woman.GetComponent<Animator>();
    }

    protected override void OnEnable() {
        base.OnEnable();
        isCorrect = false;
        progressBar.SetPause(true);
        board.SetActive(true);
    }

    protected override void OnCardPlacement()
    {
        base.OnCardPlacement();
        anim.SetTrigger("Board");
        board.SetActive(false);
        progressBar.SetPause(false);
        nextPageTimer.StartTimer(25);
    }
}