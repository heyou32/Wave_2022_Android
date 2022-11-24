using DG.Tweening.Core;
using UnityEngine;

public class ImageSeqPlayer : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnEnable() 
    {
        animator.Play("PlaySeq");
    }

    void OnEndSeq() 
    {
        gameObject.SetActive(false);
    }
}
