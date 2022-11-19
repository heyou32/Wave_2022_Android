using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePopupButton : MonoBehaviour
{
    public GameObject target;
    public GameObject other;

    private Animator targetAnim;
    private Animator otherAnim;

    private void Start() 
    {
        targetAnim = target.GetComponent<Animator>();
        otherAnim = other.GetComponent<Animator>();
    }

    public void OnClick() 
    {
        if (target.activeSelf) 
        {
            targetAnim.Play("Close");
        }
        else 
        {
            target.SetActive(true);
            targetAnim.Play("Open");
            otherAnim.Play("Close");
        }
    }
}
