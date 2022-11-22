using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPlaceTargetSetter : MonoBehaviour
{
    public BoardCardPlacement boardCardPlacement;
    public PageProgressBar progressBar;
    public GameObject woman;
    public NextPageTimer nextPageTimer;
    Animator anim;
    private void Start() 
    {
        anim = woman.GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        progressBar.SetPause(true);
        boardCardPlacement.targetList = new GameObject[1] { gameObject };
        boardCardPlacement.isCorrect = false;
    }

    public void DoAction() 
    {
        anim.SetTrigger("Board");
        progressBar.SetPause(false);
        nextPageTimer.StartTimer(25);
        boardCardPlacement.transform.parent.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }
}
