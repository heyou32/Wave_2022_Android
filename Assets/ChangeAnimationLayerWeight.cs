using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationLayerWeight : MonoBehaviour
{

    public Animator animator;

    public void SetWeightToLayer1(float weight)
    {
        StartCoroutine(IeSetAnimationWeight(1, weight)); ;
    }

    public void SetWeightToLayer2(float weight)
    {
        StartCoroutine(IeSetAnimationWeight(2, weight)); ;
    }


    private IEnumerator IeSetAnimationWeight(int layer, float weight)
    {
        float currentTime = 0;
        float startWeight = animator.GetLayerWeight(layer);
        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;
            animator.SetLayerWeight(layer, Mathf.Lerp(startWeight, weight, currentTime));
            yield return new WaitForEndOfFrame();
        }
    }

}
